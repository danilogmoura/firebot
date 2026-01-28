using System;
using System.Collections.Generic;
using UnityEngine;
using static Firebot.Utils.StringUtils;

namespace Firebot.Bot.Component;

internal class ObjectWrapper : ComponentWrapper<Transform>
{
    public ObjectWrapper(string path) : base(path) { }

    public List<ObjectWrapper> GetChildren() => ExecuteSafe(() =>
    {
        var children = new List<ObjectWrapper>();
        for (var i = 0; i < ChildCount(); i++)
        {
            var child = GetChild(i);
            children.Add(new ObjectWrapper(JoinPath(Path, child.name)));
        }

        return children;
    });

    public ObjectWrapper Find(string path) => ExecuteSafe(() =>
    {
        var transform = Component.Find(path);
        if (transform == null) throw new InvalidOperationException("Child not found: " + path);
        return new ObjectWrapper(JoinPath(Path, path));
    });
}