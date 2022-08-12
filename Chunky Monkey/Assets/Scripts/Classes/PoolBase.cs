using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;
using System;

public abstract class PoolBase<T> : MonoBehaviour where T : MonoBehaviour
{
    private List<T> prefabs;
    private ObjectPool<T> pool;

    protected void InitPool(List<T> prefabs, int defaultCapacity = 10, int maxSize = 20, bool collectionCheck = true) {
        if (prefabs.Count == 0) throw new ArgumentException("Prefabs list is empty.");
        this.prefabs = new List<T>(prefabs);
        pool = new ObjectPool<T>(CreateSetup, GetSetup, ReleaseSetup, DestroySetup, collectionCheck, defaultCapacity, maxSize);
    }

    protected virtual T CreateSetup() => Instantiate(prefabs[UnityEngine.Random.Range(0, prefabs.Count)], transform);
    protected virtual void GetSetup(T obj) => obj.gameObject.SetActive(true);
    protected virtual void ReleaseSetup(T obj) => obj.gameObject.SetActive(false);
    protected virtual void DestroySetup(T obj) => Destroy(obj.gameObject);

    public T PoolGet() {
        if (pool == null) throw new InvalidOperationException("Trying to get from an uninitialized pool, call InitPool to init.");
        return pool.Get();
    }
        
    public void PoolRelease(T obj) => pool.Release(obj);
}