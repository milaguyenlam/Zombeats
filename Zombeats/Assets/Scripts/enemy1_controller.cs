using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class enemy1_controller : MonoBehaviour
{
    public float walkSpeed;
    Rigidbody2D rb;
    Animator animator;
    State state;

    public class State
    {
        public int currentState = 0;
        public static int IDLE = 1;
        public static int WALK = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        state = new State();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (state.currentState == 1)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        else
        {
            Vector2 vector = new Vector2(0.0f, -1.0f);
            rb.velocity = vector * walkSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lowerbound"))
        {
            Debug.Log("collision w lowerbound");
            state.currentState = State.IDLE;
            animator.SetInteger("state", state.currentState);
            Thread.Sleep(3000);
            Destroy(gameObject);
        }
    }

}
