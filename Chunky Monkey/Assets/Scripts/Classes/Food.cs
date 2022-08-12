using UnityEngine;
using System.Collections.Generic;
using System;

public class Food : MonoBehaviour
{
    #region Variables
    [SerializeField] int hungerValue = 25;
    [SerializeField] AudioClip eatSound;

    private Action<Food> killAction;
    private bool killed;
    #endregion

    public void Init(Action<Food> killAction) {
        this.killAction = killAction;
        killed = false;
    }

    public virtual void OnEat() {
        HungerBar.Instance.AddValue(hungerValue);
        // TODO: play eat sound
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (killed) return;
        if (other.TryGetComponent<PlayerController>(out PlayerController player)) {
            killed = true;
            OnEat();
            player.EatFood();
            killAction(this);
        } else if (other.CompareTag(Consts.Tags.GROUND)) {
            killed = true;
            killAction(this);
        }
    }
}
