using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Core.Pooling
{
    public class Pooler<T> : IDisposable where T : Component
    {
        private readonly Queue<T> _pool = new();
        private readonly T _prefab;
        private readonly Transform _parent;
        
        public Pooler(T prefab, Transform parent, int initialSize)
        {
            _prefab = prefab;
            _parent = parent;
            
            Pool(initialSize);
        }
        
        public T Get()
        {
            if (_pool.Count > 0)
            {
                T instance = _pool.Dequeue();
                instance.gameObject.SetActive(true);
                return instance;
            }
            else
            {
                return IncreaseSizeAndGet();
            }
        }
        
        public void Return(T instance)
        {
            instance.gameObject.SetActive(false);
            _pool.Enqueue(instance);
        }
        
        public void Dispose()
        {
            while (_pool.Count > 0)
            {
                T instance = _pool.Dequeue();
                Object.Destroy(instance.gameObject);
            }
        }

        private void Pool(int size)
        {
            for (int i = 0; i < size; i++)
            {
                T instance = Object.Instantiate(_prefab, _parent);
                instance.gameObject.SetActive(false);
                _pool.Enqueue(instance);
            }
        }

        private T IncreaseSizeAndGet()
        {
            Pool(1);
            return Get();
        }
    }
}