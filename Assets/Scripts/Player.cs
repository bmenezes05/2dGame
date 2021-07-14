using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;

    private bool isGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }

    private bool hittedSpike()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().hittedSpike;
    }

    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
        Jump();
        ControlAnimations();
        GameOver();
    }

    private void GameOver()
    {
        if (hittedSpike())
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

    private void ControlAnimations()
    {
        anim.SetBool("jump", !isGrounded());

        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    private void Move()
    {
        rig.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * Speed, rig.velocity.y);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded())
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
            }
            else if (doubleJump)
            {
                rig.AddForce(new Vector2(0f, JumpForce * 1.2f), ForceMode2D.Impulse);
                doubleJump = false;
            }
        }
    }
}