using UnityEngine;
using System.Collections.Generic;

public class GoodFood : Food
{
    #region Variables
    [SerializeField] int scoreValue = 5;
    [SerializeField] Vector2 startVelocity = Vector2.down;
    [SerializeField] float dropAfterSeconds = 1.5f;

    private float timeFromStart;
    private Rigidbody2D rb;
    #endregion

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
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
