using UnityEngine;
using System.Collections.Generic;

public class HungerBar : SliderBar
{
    #region Variables
    public static HungerBar Instance;

    [SerializeField] float decreaseEverySec = 10;
    #endregion

    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    void Update()
    {
        AddValue(-decreaseEverySec * Time.deltaTime);
    }
}
