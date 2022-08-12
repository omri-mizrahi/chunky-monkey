using UnityEngine;
using System.Collections.Generic;

public class GoodFood : Food
{
    #region Variables
    [SerializeField] int scoreValue = 5;
    #endregion

    void Start() {
        // TODO: hang a sec in place, than drop down
    }

    public override void OnEat() {
        base.OnEat();
        ScoreCounter.Instance.UpdateScore(scoreValue);
    }
}
