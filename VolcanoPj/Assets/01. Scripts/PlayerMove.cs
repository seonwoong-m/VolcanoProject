using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 playerPos;
    Animator anim;

    public ButtonManager[] buttons;

    public float moveSpeed = 5f;

    bool isJump = false;
    bool MoveY = false;
    bool isJumped = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            buttons[0].isPush = true;
        }
        else
        {
            buttons[0].isPush = false;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            buttons[1].isPush = true;
        }
        else
        {
            buttons[1].isPush = false;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            buttons[2].isPush = true;
        }
        else
        {
            buttons[2].isPush = false;
        }

        if(Input.GetKey(KeyCode.Space))
        {
            buttons[3].isPush = true;
        }
        else
        {
            buttons[3].isPush = false;
        }
#endif

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x <= 0.08f)
            pos.x = 0.08f;

        if (pos.x >= 0.92f)
            pos.x = 0.92f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);


        if (buttons[0].isPush)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
            transform.localScale = new Vector3(-1.7f, 1.7f, 1);
            pos.x = Mathf.Clamp(pos.x, -2f, 2f);
        }
        else
        {
        }

        if (buttons[1].isPush)
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
            transform.localScale = new Vector3(1.7f, 1.7f, 1);
            pos.x = Mathf.Clamp(pos.x, -2f, 2f);
        }
        else
        {
        }

        if (buttons[2].isPush)
        {
        }
        else
        {
        }

        if (buttons[3].isPush)
        {
            if (!isJump)
            {
                JumpTrue();
                isJump = true;
                MoveY = true;
            }
        }
        else
        {
        }

        if(buttons[0].isPush == true || buttons[1].isPush == true)
        {
            anim.SetBool("MoveX", true);
        }
        else
        {
            anim.SetBool("MoveX", false);
        }

        anim.SetBool("MoveY", MoveY);
        anim.SetBool("IsJumped", isJumped);
    }

    void JumpTrue()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 5);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "GROUND")
        {
            isJump = false;
        }
    }
}
