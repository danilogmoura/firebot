using UnityEngine;
using UnityGameObject = UnityEngine.GameObject;

namespace FireBot.Bot.Component
{
    internal abstract class MappedObjectBase
    {
        private readonly string _path;
        private Transform _cachedTransform;

        protected MappedObjectBase(string path)
        {
            _path = path;
        }

        protected Transform CachedTransform
        {
            get
            {
                if (_cachedTransform != null) return _cachedTransform;

                FindAndCacheTransform();
                return _cachedTransform;
            }
        }

        private void FindAndCacheTransform()
        {
            if (string.IsNullOrEmpty(_path)) return;

            var firstSlashIndex = _path.IndexOf('/');

            UnityGameObject rootObj;
            Transform targetTrans = null;

            if (firstSlashIndex == -1)
            {
                rootObj = UnityGameObject.Find(_path);
                if (rootObj != null) targetTrans = rootObj.transform;
            }
            else
            {
                var rootName = _path.Substring(0, firstSlashIndex);
                var childPath = _path.Substring(firstSlashIndex + 1);

                rootObj = UnityGameObject.Find(rootName);
                if (rootObj != null) targetTrans = rootObj.transform.Find(childPath);
            }

            _cachedTransform = targetTrans;
        }

        public bool Exists()
        {
            return CachedTransform != null;
        }

        public bool IsActive()
        {
            return CachedTransform?.gameObject.activeInHierarchy ?? false;
        }

        public bool IsActiveSelf()
        {
            return CachedTransform?.gameObject.activeSelf ?? false;
        }
    }
}