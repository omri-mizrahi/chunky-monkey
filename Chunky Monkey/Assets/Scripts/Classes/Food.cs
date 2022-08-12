using UnityEngine;
using System.Collections.Generic;
using System;

public class Food : MonoBehaviour
{
    #region Variables
    [SerializeField] int hungerValue = 25;
    [SerializeField] AudioClip eatSound;

    private Action<Food> killAction;
    #endregion

    public void Init(Action<Food> killAction) {
        this.killAction = killAction;
    }

    public virtual void OnEat() {
        HungerBar.Instance.AddValue(hungerValue);
        // TODO: play eat sound
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.TryGetComponent<PlayerController>(out PlayerController player)) {
            OnEat();
            player.EatFood();
            killAction(this);
        } else if (other.CompareTag(Consts.Tags.GROUND)) {
            killAction(this);
        }
    }
}
