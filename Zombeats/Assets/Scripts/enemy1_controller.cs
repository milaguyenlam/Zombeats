using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_controller : enemy_controller
{
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        state = State.WALK;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Lowerbound"))
        {
            Debug.Log("collision w lowerbound");
            attack();
            if (lives < 1)
            {
                die();
            }
        }
        else if(collision.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("enemy hit by an ammo");
            
            attack();
            if (lives < 1)
            {
                die();
            }
        }
    }

    public override void move()
    {
        if (state == State.DEATH)
        {
            rb.velocity = Vector2.zero;

        }
        else if (state == State.ATTACK)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            Vector2 vector = new Vector2(0.0f, -1.0f);
            rb.velocity = vector * speed;
        }
    }

    public override void attack()
    {
        state = State.ATTACK;
        lives--;
        LaunchAnimation(state);
        Invoke("walk", 1f); //time parameter should correspond with attack animation duration
    }

    public override void die()
    {
        state = State.DEATH;
        LaunchAnimation(state);
        Invoke("Dissapear", 1f); //time parameter should correspond with death animation duration
    }


    public override void reaction()
    {
        
    }

    void Dissapear()
    {
        Destroy(gameObject);
    }

    void LaunchAnimation(State state)
    {
        animator.SetInteger("state", (int)state);
    }

    void walk()
    {
        state = State.WALK;
        LaunchAnimation(state);
    }

}
