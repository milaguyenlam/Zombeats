﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_controller : MonoBehaviour
{
    public GameObject crosshair;
    public float moveDelta;
    private Vector2 startAim;
    private CircleCollider2D collider2D;
    private SpriteRenderer sprite;
    private Vector2 target;

    private enum State { FRESH, EXPIRED, ROTTEN }
    private State state;
    private Animator animator;
    //states for animation
    public enum Type { VEGAN, DAIRYFREE, MEAT }
    public Type type;
    //type of the ammo

    //variables for throw animation
    private float g = 10f;
    private float v;
    private float alfa = 45f;
    private float distance;
    private Vector2 startScale;


    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<CircleCollider2D>();
        startAim = crosshair.GetComponent<shooting_controller>().startAim; //depends on player position

        distance = Vector2.Distance(startAim, target);
        v = Mathf.Sqrt(distance * g / Mathf.Sin(2 * alfa));
        startScale = transform.localScale;

        Disable();

    }

    public void loadType(Type type)
    {
        this.type = type;
        sprite = GetComponent<SpriteRenderer>();
        switch (type)
        {
            case Type.MEAT:
                Debug.Log("color set");
                sprite.material.SetColor("_Color", Color.red);
                break;
            case Type.DAIRYFREE:
                Debug.Log("color set");
                sprite.material.SetColor("_Color", Color.white);
                break;
            case Type.VEGAN:
                Debug.Log("color set");
                sprite.material.SetColor("_Color", Color.green);
                break;
            default:
                break;
        }

    }

    public void loadTarget(Vector2 target)
    {
        this.target = target;
    }

    private void Disable()
    {
        collider2D.enabled = false;
    }

    private void Enable()
    {
        collider2D.enabled = true;
        
    }

    private void Dissapear()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move();
        throwanim();
        if (Vector2.Distance(transform.position, target) <= 0.1f)
        {
            Enable();
            Invoke("Dissapear", 2.0f);
        }
    }

    private void move()
    {
        Vector2 position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target, moveDelta);
        transform.position = position;
    }

    private void throwanim()
    {
        float cur_distance = Vector2.Distance(transform.position, target);
        float t = cur_distance / (v * Mathf.Cos(alfa));
        float y = cur_distance * Mathf.Tan(alfa) - g / 2 * Mathf.Pow(t, 2f);

        transform.localScale = startScale * (1 + y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}