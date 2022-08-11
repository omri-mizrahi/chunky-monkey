using UnityEngine;
using System.Collections.Generic;

public class BadFood : Food
{
    #region Variables
    [SerializeField] int dentalDamage = 30;
    #endregion

    public override void OnEat() {
        base.OnEat();
        DentalHealth.Instance.AddValue(-dentalDamage);
    }
}
