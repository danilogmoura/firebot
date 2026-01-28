using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Logger = Firebot.Utils.Logger;
using UnityGameObject = UnityEngine.GameObject;

namespace Firebot.Bot.Components.Base;

internal abstract class MappedObjectBase
{
    protected readonly Logger Log;
    protected readonly string Path;
    private Transform _cachedTransform;

    protected MappedObjectBase(string path)
    {
        Path = path;
        Log = new Logger(GetType().Name);
    }

    public string Name => ExecuteSafe(() => CachedTransform?.name ?? string.Empty);

    protected Transform CachedTransform
    {
        get
        {
            if (_cachedTransform == null) FindAndCacheTransform();
            return _cachedTransform;
        }
    }

    private void FindAndCacheTransform() =>
        ExecuteSafe(() =>
        {
            if (string.IsNullOrEmpty(Path)) return;
            var rootObj = UnityGameObject.Find(Path.Split('/')[0]);

            if (rootObj == null)
                throw new InvalidOperationException(
                    $"[MapError] {nameof(MappedObjectBase)}: Root not found for {Path}");

            _cachedTransform = !Path.Contains('/')
                ? rootObj.transform
                : rootObj.transform.Find(Path.Substring(Path.IndexOf('/') + 1));

            if (_cachedTransform != null) Log.Debug($"Cached {Path}");
        });

    public void ExecuteSafe(Action action, [CallerMemberName] string actionName = null)
    {
        try
        {
            action?.Invoke();
        }
        catch (Exception ex)
        {
            Log.Error($"Exception in '{actionName}': {ex.Message}");
            Log.Debug($"Full StackTrace for {actionName}:\n{ex}");
        }
    }

    public T ExecuteSafe<T>(Func<T> func, T defaultValue = default, [CallerMemberName] string actionName = "")
    {
        try
        {
            return func();
        }
        catch (Exception ex)
        {
            Log.Error($"Exception in '{actionName}': {ex.Message}");
            Log.Debug($"Full StackTrace for {actionName}:\n{ex}");
            return defaultValue;
        }
    }

    public virtual bool Exists() => CachedTransform != null;

    public virtual bool IsActive() => Exists() && CachedTransform.gameObject.activeInHierarchy;

    public bool HasChildren() => IsActive() && ExecuteSafe(() => CachedTransform.childCount > 0);

    public int ChildCount() => Exists() ? CachedTransform.childCount : 0;

    public Transform GetChild(int level) => ExecuteSafe(() => CachedTransform?.GetChild(level));
}