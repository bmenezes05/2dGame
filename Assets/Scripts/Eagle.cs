using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public float fallingTime;

    public float speed;
    public bool isDirectionUp = true;
    public bool move = true;
    public float timer;
    public float moveTime;

    private SpriteRenderer sp;

    public GameObject enemyDeath;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!move)
        {
            transform.Translate(Vector2.zero);
        }
        else if (isDirectionUp)
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
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 40, ForceMode2D.Impulse);
            EnemyDead();                        
        }
    }
        
    void EnemyDead()
    {
        sp.color = new Color(0f, 0f, 0f, 0f);
        move = false;
        enemyDeath.SetActive(true);        
        Invoke("DestroyEnemy", 0.2f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
