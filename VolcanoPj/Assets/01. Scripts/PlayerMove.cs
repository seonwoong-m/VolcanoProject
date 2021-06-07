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
    float jumpTime = 0f;
    float attackTime = 0f;

    bool isJump = false;
    bool MoveY = false;
    bool isJumped = false;
    bool isAttack1 = false;
    bool isAttack2 = false;

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
            if(!isAttack1)
            isAttack1 = true;
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

        if(buttons[0].isPush || buttons[1].isPush)
        {
            anim.SetBool("MoveX", true);

        }
        else
        {
            anim.SetBool("MoveX", false);
        }
        
        if(isJump)
        {
            jumpTime += Time.deltaTime;

            if(jumpTime >= 0.1f)
            {
                isJumped = true;
                anim.SetBool("IsJumped", isJumped);
                jumpTime = 0f;
            }
        }

        if(isAttack1)
        {
            

            attackTime += Time.deltaTime;

            if(attackTime >= 0.5f)
            {
                isAttack1 = false;
                attackTime = 0f;
            }
        }
        
        anim.SetBool("IsAttack1", isAttack1);
        anim.SetBool("MoveY", MoveY);
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
            isJumped = false;
            MoveY = false;
            anim.SetBool("IsJumped", isJumped);
        }
    }
}
