using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public float fallingTime;

    public float speed;
    public bool isDirectionUp = true;
    public float timer;
    public float moveTime;

    private TargetJoint2D target;
    private BoxCollider2D box;
    private Rigidbody2D rig;

    public GameObject enemyDeath;

    void Start()
    {
        target = GetComponent<TargetJoint2D>();
        box = GetComponent<BoxCollider2D>();
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDirectionUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }

        timer += Time.deltaTime;

        if(timer >= moveTime)
        {
            isDirectionUp = !isDirectionUp;
            timer = 0f;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300, ForceMode2D.Impulse);
            enemyDeath.SetActive(true);
            Invoke("Falling", fallingTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Destroy(gameObject);
        }
    }

    void Falling()
    {
        rig.gravityScale = 140f;
        target.enabled = false;
        box.isTrigger = true;
    }
}
