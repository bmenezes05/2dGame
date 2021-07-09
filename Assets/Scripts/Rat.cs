using UnityEngine;

public class Rat : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer sp;

    public float speed;

    public Transform rightCol;
    public Transform leftCol;
    public Transform headPoint;

    private bool colliding;

    public LayerMask layer;

    public GameObject enemyDeath;

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);

        colliding = Physics2D.Linecast(rightCol.position, leftCol.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed = -speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float height = collision.GetContact(0).point.y - headPoint.position.y;
            
            if (height > 0)
            {                                
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 300, ForceMode2D.Impulse);
                EnemyDead();
            }
        }
    }

    void EnemyDead()
    {
        sp.color = new Color(0f, 0f, 0f, 0f);
        speed = 0;
        enemyDeath.SetActive(true);
        Invoke("DestroyEnemy", 0.2f);
    }

    void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}