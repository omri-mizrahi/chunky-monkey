using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] float speed;
    [SerializeField] float XBoundaryRange;

    Rigidbody2D rb;
    float horizontalInput;
    #endregion

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis(Consts.Input.HORIZONTAL);
    }

    void FixedUpdate() {
        rb.velocity = (horizontalInput * speed) * Vector2.right;

        Vector2 pos = transform.position;
        if (Mathf.Abs(pos.x) >= XBoundaryRange) {
            pos.x = pos.x > 0 ? -XBoundaryRange : XBoundaryRange;
            transform.position = pos;
        }
    }
}
