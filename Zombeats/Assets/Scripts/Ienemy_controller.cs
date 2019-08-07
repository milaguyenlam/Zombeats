using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemy_controller : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public int lives;
    public float speed;
    public enum State { WALK, IDLE, ATTACK, DEATH}
    public State state;

    public enum Diet { VEGETARIAN, VEGAN, DAIRYFREE, MEAT}
    public Diet diet;

    public abstract void move();
    public abstract void attack();
    public abstract void die();
    public abstract void reaction();
}
