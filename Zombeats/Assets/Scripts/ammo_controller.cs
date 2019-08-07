using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo_controller : MonoBehaviour
{
    private Vector2 target;
    public float velocity;
    private readonly Vector2 startAim = new Vector2(0f, -3.4f);
    private CircleCollider2D collider;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        Disable();
    }

    public void loadTarget(Vector2 target)
    {
        this.target = target;
    }

    private void Disable()
    {
        collider.enabled = false;
    }

    private void Enable()
    {
        collider.enabled = true;
        sprite.material.SetColor("_Color", Color.green);
        
    }

    private void Dissapear()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), target, 0.1f);
        transform.position = position;
        if (Vector2.Distance(transform.position, target) <= 0.1f)
        {
            Enable();
            Invoke("Dissapear", 2.0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
