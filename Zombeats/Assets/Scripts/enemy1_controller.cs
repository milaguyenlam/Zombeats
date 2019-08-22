using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1_controller : MonoBehaviour, Ienemy_controller
{
    private GameObject spawner;
    private Rigidbody2D rb;
    private Animator animator;

    public int lives;
    public float speed;
    private enum State { WALK, IDLE, ATTACK, DEATH }
    private State state;
    public enum Diet { VEGAN, DAIRYFREE, MEAT }
    public Diet diet;

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
        if (collision.gameObject.CompareTag("HUD"))
        {
            Debug.Log("collision w lowerbound");
            attack();
            collision.gameObject.GetComponent<HUD_controller>().gotHit();
            if (lives < 1)
            {
                die();
            }

        }
        else if(collision.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("enemy hit by an ammo");
            //if ammo corresponds to enemy diet then attack()
            Debug.Log(collision.gameObject.GetComponent<ammo_controller>().type + "-" + diet);
            attack(collision.gameObject);
            if (lives < 1)
            {
                die();
            }

        }
    }

    public void move()
    {
        if (state == State.WALK)
        {
            Vector2 vector = new Vector2(0.0f, -1.0f);
            rb.velocity = vector * speed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void attack(GameObject go)
    {
        state = State.ATTACK;
        if ((int)go.GetComponent<ammo_controller>().type == (int)diet)
        {
            lives--;
        }
        LaunchAnimation(state);
        Invoke("walk", 1f); //time parameter should correspond with duration of attack animation
        spawner.GetComponent<enemySpawner_controller>().enemyDie();
    }

    public void attack()
    {
        state = State.ATTACK;
        lives--;
        LaunchAnimation(state);
        Invoke("walk", 1f); //time parameter should correspond with duration of attack animation
        spawner.GetComponent<enemySpawner_controller>().enemyDie();
    }

    public void die()
    {
        state = State.DEATH;
        LaunchAnimation(state);
        Invoke("Dissapear", 1f); //time parameter should correspond with duration of death animation
    }


    public void reaction()
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

    public void setSpawner(GameObject spawner)
    {
        this.spawner = spawner;
    }

    public void loadDiet(Diet diet)
    {
        this.diet = diet;
    }

}
