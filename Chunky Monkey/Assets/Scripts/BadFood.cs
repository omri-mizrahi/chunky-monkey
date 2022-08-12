using UnityEngine;
using System.Collections.Generic;

public class BadFood : Food
{
    #region Variables
    [SerializeField] int dentalDamage = 30;
    #endregion

    void OnEnable() {
        // TODO: apply random toss (radom force vector, radnom torque)
    }

    public override void OnEat() {
        base.OnEat();
        DentalHealth.Instance.AddValue(-dentalDamage);
    }
}
