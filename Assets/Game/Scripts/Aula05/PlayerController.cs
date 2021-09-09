using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    [Range(0f, 100f)] public float speed;
    public float jumpForce;


    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began)
            {
                rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
            }
        }
    }
}
