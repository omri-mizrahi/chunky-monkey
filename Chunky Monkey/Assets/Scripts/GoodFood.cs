using UnityEngine;
using System.Collections.Generic;
using System;

public class GoodFood : Food
{
    #region Variables
    [SerializeField] int scoreValue = 5;
    [SerializeField] Vector2 startVelocity = Vector2.down;
    [SerializeField] float dropAfterSeconds = 1.5f;

    private float timeFromStart;
    #endregion

    public override void Init(Action<Food> killAction)
    {
        base.Init(killAction);
        timeFromStart = 0f;
    }

    void FixedUpdate() {
        timeFromStart += Time.fixedDeltaTime;
        if (timeFromStart < dropAfterSeconds) {
            rb.velocity = startVelocity;
        }
    }

    public override void OnEat() {
        base.OnEat();
        ScoreCounter.Instance.UpdateScore(scoreValue);
    }
}
