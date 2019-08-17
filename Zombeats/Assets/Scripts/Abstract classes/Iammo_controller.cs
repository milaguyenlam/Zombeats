using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Iammo_controller : MonoBehaviour
{
    public GameObject crosshair;
    public float moveDelta;
    public Vector2 startAim;
    public CircleCollider2D collider;
    public SpriteRenderer sprite;
    public Vector2 target;

    public enum State { FRESH, EXPIRED, ROTTEN }
    public State state;
    public Animator animator;
    //states for animation
    public Rigidbody2D rb;
    public int lives;
    //special ammo with more than 1 life
    public enum Type { VEGAN, DAIRYFREE, MEAT }
    public Type type;
    //type of the ammo

    public abstract void move();



    

   
}
