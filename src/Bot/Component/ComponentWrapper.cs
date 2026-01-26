namespace Firebot.Bot.Component;

internal abstract class ComponentWrapper<T> : MappedObjectBase where T : UnityEngine.Component
{
    private T _componentCached;

    protected ComponentWrapper(string path) : base(path) { }

    protected T ComponentCached =>
        ExecuteSafe(() =>
        {
            if (_componentCached != null) return _componentCached;
            CachedTransform.TryGetComponent(out _componentCached);
            return _componentCached;
        });

    protected override bool Exists() => base.Exists() && CachedTransform != null;
}