using UnityEngine;
using System.Collections.Generic;

public class FoodSpawner : PoolBase<Food>
{
    // TODO: try with only 3 prefabs, see if the order always the same
    #region Variables
    [SerializeField] List<Food> prefabs;
    
    [Header("Spawn Rate")]
    [SerializeField] float startSpawnRate = 2f;
    [SerializeField] float accelerationOverTime = .1f;
    [SerializeField] float stopSpawnRate = .5f;
    [SerializeField] float initialDelay = 0f;
    
    [Header("Spawn Position")]
    [SerializeField] List<TwoPointsRange> spawnPosRanges;

    float spawnRate;
    float spawnCooldown;
    #endregion

    void Awake()
    {
        spawnRate = startSpawnRate;
        InitPool(prefabs);
    }

    void Start() {
        SetSpawnCooldown();
        spawnCooldown += initialDelay;
    }

    void Update()
    {
        spawnCooldown -= Time.deltaTime;
        if (spawnCooldown <= 0) {
            SetSpawnCooldown();
            PoolGet();
        }
        
        if ((startSpawnRate < stopSpawnRate && spawnRate < stopSpawnRate) || (startSpawnRate > stopSpawnRate && spawnRate > stopSpawnRate)) {
            spawnRate -= accelerationOverTime * Time.deltaTime;
        }
    }

    void SetSpawnCooldown() {
        spawnCooldown = spawnRate;
    }

    void KillAction(Food food) {
        PoolRelease(food);
    }

    protected override void GetSetup(Food food)
    {
        food.transform.position = spawnPosRanges[Random.Range(0, spawnPosRanges.Count)].GetPointInRange();
        food.gameObject.SetActive(true);
        food.Init(KillAction);
    }
}
