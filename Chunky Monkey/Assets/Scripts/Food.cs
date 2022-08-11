using UnityEngine;
using System.Collections.Generic;

public class Food : MonoBehaviour
{
    #region Variables
    [SerializeField] int hungerValue = 25;
    [SerializeField] AudioClip eatSound;
    #endregion

    public virtual void OnEat() {
        HungerBar.Instance.AddValue(hungerValue);
        // play eat sound
    }
}
