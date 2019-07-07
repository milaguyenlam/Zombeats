using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_controller : MonoBehaviour
{
    public BoxCollider2D cb;
    public float walkSpeed;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 vector = new Vector2(0.0f, -1.0f);
        rb.velocity = vector * walkSpeed;
    }
}
