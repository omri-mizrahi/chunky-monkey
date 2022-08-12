using UnityEngine;
using System.Collections.Generic;

public class BadFood : Food
{
    #region Variables
    [SerializeField] int dentalDamage = 30;

    [Header("Toss settings")]
    [SerializeField] Vector2 throwTowards = Vector2.zero;
    [SerializeField] float minRightAngle = 30f;
    [SerializeField] float maxRightAngle = 80f;
    [SerializeField] float mirrorAngleInc = 70f;
    [SerializeField] float force = 2f;
    [SerializeField] float minTorque = -10f;
    [SerializeField] float maxTorque = 10f;
    #endregion

    public override void Init(System.Action<Food> killAction)
    {
        // TODO: apply random toss (radom force vector, radnom torque)
        base.Init(killAction);
        Toss();
    }

    void Toss() {
        rb.AddForce(RandomAngleForce(), ForceMode2D.Impulse);
        rb.AddTorque(Random.Range(minTorque, maxTorque), ForceMode2D.Force);
    }

    Vector2 RandomAngleForce() {
        Vector2 currPos = transform.position;
        Vector2 towardsTarget = throwTowards - currPos;
        float rndAngle;
        if (towardsTarget.x < 0) {
            rndAngle = Random.Range(minRightAngle + mirrorAngleInc, maxRightAngle + mirrorAngleInc);
        } else {
            rndAngle = Random.Range(minRightAngle, maxRightAngle);
        }
        
        float x = Mathf.Cos(rndAngle * Mathf.PI / 180) * force;
        float y = Mathf.Sin(rndAngle * Mathf.PI / 180) * force;
        return new Vector2(x, y);
    }
    
    public override void OnEat() {
        base.OnEat();
        DentalHealth.Instance.AddValue(-dentalDamage);
    }
}
