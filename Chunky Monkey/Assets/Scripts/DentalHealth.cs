using UnityEngine;
using System.Collections.Generic;

public class DentalHealth : SliderBar
{
    #region Variables
    public static DentalHealth Instance;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
}
