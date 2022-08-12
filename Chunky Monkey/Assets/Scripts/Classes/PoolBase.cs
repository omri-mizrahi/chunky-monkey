using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class PoolBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private ObjectPool<T> pool;

    protected void InitPool(int defaultCapacity = 10, int maxSize = 20, bool collectionCheck = true) {
        if (Prefabs.Count == 0) throw new ArgumentException("Prefabs list is empty.");
        pool = new ObjectPool<T>(CreateSetup, GetSetup, ReleaseSetup, DestroySetup, collectionCheck, defaultCapacity, maxSize);
    }

    protected abstract List<T> Prefabs { get; }

    protected virtual T CreateSetup() {
        List<T> _prefabs = Prefabs;
        return Instantiate(_prefabs[UnityEngine.Random.Range(0, _prefabs.Count)], transform);
    }
    protected virtual void GetSetup(T obj) => obj.gameObject.SetActive(true);
    protected virtual void ReleaseSetup(T obj) => obj.gameObject.SetActive(false);
    protected virtual void DestroySetup(T obj) => Destroy(obj.gameObject);

    public T PoolGet() {
        if (pool == null) throw new InvalidOperationException("Trying to get from an uninitialized pool, call InitPool to init.");
        return pool.Get();
    }
    public void PoolRelease(T obj) => pool.Release(obj);
}