using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SliderBar : MonoBehaviour
{
    #region Variables
    [SerializeField] float maxValue = 100;
    [SerializeField] Gradient colorGradient;
    [SerializeField] Image fill;
    
    private Slider slider;
    private float currValue;
    #endregion

    protected virtual void Awake()
    {
        slider = GetComponent<Slider>();
        SetMaxValue(maxValue);
    }

    public void AddValue(float inc) {
        currValue += inc;
        if (currValue > maxValue) currValue = maxValue;
        SetValue(currValue);
        // TODO: call check game over from game manager
    }

    void SetValue(float value) {
        slider.value = value;
        fill.color = colorGradient.Evaluate(slider.normalizedValue);
    }

    void SetMaxValue(float value) {
        currValue = value;
        slider.maxValue = value;
        SetValue(value);
    }
}
