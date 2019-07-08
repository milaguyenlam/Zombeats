using System.Collections;
using System.Collections.Generic;
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
        public static readonly int WALK = 0;
        public static readonly int ATTACK = 1;
        public static readonly int DEATH = 2;
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
        if (state.currentState == State.DEATH)
        {
            rb.velocity = Vector2.zero;

        }
        else if(state.currentState == State.ATTACK)
        {
            rb.velocity = Vector2.zero;
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
            state.currentState = State.DEATH;
            animator.SetInteger("state", state.currentState);
            Destroy(gameObject);
        }
        else if(collision.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("enemy hit by an ammo");
            state.currentState = State.ATTACK;
            Destroy(gameObject);
        }
    }

}
