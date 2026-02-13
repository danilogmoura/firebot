using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Firebot.Utilities;
using UnityEngine;
using static Firebot.Utilities.StringUtils;
using Logger = Firebot.Core.Logger;

namespace Firebot.GameModel.Base;

public class GameElement
{
    private readonly string _className;
    private readonly string _path;

    public GameElement(string path = null, GameElement parent = null, Transform transform = null)
    {
        _className = GetType().Name;
        _path = path?.Trim('/');

        var baseTransform = parent?.Root ?? transform;
        if (!string.IsNullOrEmpty(_path) && baseTransform != null)
        {
            var resolved = baseTransform.Find(_path);
            if (resolved != null)
                _path = resolved.GetPath();
            else
                Debug($"Child transform not found. Parent: {baseTransform.name}, Path: {Ellipsize(_path)}");
        }
        else if (string.IsNullOrEmpty(_path) && baseTransform != null)
        {
            _path = baseTransform.GetPath();
            Debug($"Path derived from base transform: {Ellipsize(_path)}");
        }

        var source = string.Join(" | ", new[]
        {
            baseTransform != null ? $"Parent: {baseTransform.name}" : null,
            !string.IsNullOrEmpty(_path) ? $"Path: {Ellipsize(_path)}" : null
        }.Where(s => s != null));

        Debug($"Initialized {_className} with {source}");
    }

    public Transform Root
    {
        get
        {
            if (!string.IsNullOrEmpty(_path))
            {
                var resolved = FindAbsolute(_path);
                if (resolved == null)
                    Debug($"Absolute path not found: {Ellipsize(_path)}");

                return resolved;
            }

            Debug("Root resolution skipped (no parent, no path, no immediate transform)");
            return null;
        }
    }

    private static Transform FindAbsolute(string fullPath)
    {
        var firstSlash = fullPath.IndexOf('/');

        if (firstSlash == -1)
            return GameObject.Find(fullPath)?.transform;

        var rootName = fullPath[..firstSlash];
        var relativePath = fullPath[(firstSlash + 1)..];

        var rootObj = GameObject.Find(rootName);
        return rootObj != null ? rootObj.transform.Find(relativePath) : null;
    }

    public virtual bool IsVisible() => Root != null && Root.gameObject.activeInHierarchy;

    public IEnumerable<GameElement> GetChildren()
    {
        var currentRoot = Root;
        if (currentRoot == null)
        {
            Debug("GetChildren called but root is null");
            yield break;
        }

        foreach (var o in currentRoot)
        {
            var child = (Transform)o;
            yield return new GameElement(transform: child);
        }
    }

    public bool TryGetComponent<T>(out T component) where T : Component
    {
        component = null;
        var root = Root;
        if (root == null)
        {
            Debug($"TryGetComponent<{typeof(T).Name}> failed: root is null");
            return false;
        }

        var success = root.TryGetComponent(out component);
        if (!success)
            Debug($"TryGetComponent<{typeof(T).Name}> failed on: {root.name}");

        return success;
    }

    protected void Debug(string message, [CallerMemberName] string member = "", [CallerLineNumber] int line = 0)
        => Logger.Debug($"[{_className}::{member}:{line}] {message}");
}