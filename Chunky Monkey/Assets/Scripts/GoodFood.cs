using UnityEngine;
using System.Collections.Generic;

public class GoodFood : Food
{
    #region Variables
    [SerializeField] int scoreValue = 5;
    #endregion

    public override void OnEat() {
        base.OnEat();
        ScoreCounter.Instance.UpdateScore(scoreValue);
    }
}
