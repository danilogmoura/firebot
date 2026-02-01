using UnityEngine;
using Logger = Firebot.Old.Core.Diagnostics.Logger;

namespace Firebot.GameModel.Base;

public class GameElement
{
    protected Transform _cachedTransform;

    public GameElement(string path, string contextName, GameElement parent = null)
    {
        Path = path?.Trim('/');
        Parent = parent;
        ContextName = contextName;
    }

    public string Path { get; protected set; }
    public string ContextName { get; protected set; }
    protected GameElement Parent { get; }

    public Transform Root
    {
        get
        {
            if (_cachedTransform != null) return _cachedTransform;

            if (string.IsNullOrEmpty(Path) && Parent == null)
            {
                Debug("Path is null or empty and no parent. Cannot resolve root.");
                return null;
            }

            if (Parent != null)
            {
                var parentTrans = Parent.Root;
                if (parentTrans == null)
                {
                    Debug("Parent is null. Returning parent's root");
                    return null;
                }

                _cachedTransform = parentTrans.Find(Path);

                Debug(_cachedTransform == null
                    ? $"Failed to resolve '{Path}' under parent '{Parent.ContextName}'"
                    : $"Resolved '{Path}' under parent '{Parent.ContextName}'");
            }
            else
            {
                var obj = GameObject.Find(Path);
                if (obj != null)
                {
                    _cachedTransform = obj.transform;
                    Debug($"Resolved '{Path}' under '{obj?.name}'");
                }
                else
                    Debug($"Failed to resolve '{Path}' from root");
            }

            return _cachedTransform;
        }
    }

    public bool IsVisible() => Root != null && Root.gameObject.activeInHierarchy;

    public bool TryGetComponent<T>(out T component) where T : Component
    {
        component = null;
        return Root == null && Root.TryGetComponent(out component);
    }

    protected void Log(string msg) => Logger.Info(ContextName, msg);
    protected void LogWarning(string msg) => Logger.Warning(ContextName, msg);
    protected void LogError(string msg) => Logger.Error(ContextName, msg);
    protected void Debug(string msg) => Logger.Debug(ContextName, msg);
}