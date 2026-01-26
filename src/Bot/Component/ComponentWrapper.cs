namespace Firebot.Bot.Component;

internal abstract class ComponentWrapper<T> : MappedObjectBase where T : UnityEngine.Component
{
    private T _componentCached;

    protected ComponentWrapper(string path) : base(path) { }

    protected T ComponentCached =>
        ExecuteSafe(() =>
        {
            if (_componentCached != null) return _componentCached;
            if (CachedTransform != null) _componentCached = CachedTransform.GetComponent<T>();
            return _componentCached;
        });

    public bool HasComponent() => ComponentCached != null;

    public T Get() => ComponentCached;
}