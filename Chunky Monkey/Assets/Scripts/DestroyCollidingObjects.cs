using UnityEngine;
using System.Collections.Generic;

public class DestroyCollidingObjects : MonoBehaviour
{
    #region Variables
    [Tooltip("Destroy obejcts only with these gametags. Optional - if empty, destroys every object")] 
    [SerializeField] List<string> gameTagWhitelist;
    
    [Tooltip("Destroy also this object after a collision")]
    [SerializeField] bool destroySelf = false;
    
    bool whitelistNotEmpty;
    #endregion

    void Awake() {
        whitelistNotEmpty = gameTagWhitelist.Count > 0;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (whitelistNotEmpty && gameTagWhitelist.Contains(other.tag) || !whitelistNotEmpty) {
            Destroy(other.gameObject);
        }
        if (destroySelf) {
            Destroy(gameObject);
        }
    }
}
