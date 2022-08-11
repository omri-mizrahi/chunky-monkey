using UnityEngine;
using System.Collections.Generic;

public class PlayerCollisions : MonoBehaviour
{
    #region Variables
    #endregion

    void OnTriggerEnter2D(Collider2D other) {
        if(other.TryGetComponent<Food>(out Food food)) {
            food.OnEat();
            EatFood();
        }
    }

    void EatFood() {
        // TODO:
        // play animation
        // play bite sound
    }
}
