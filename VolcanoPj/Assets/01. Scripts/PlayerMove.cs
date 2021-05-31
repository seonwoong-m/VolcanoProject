using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Vector2 playerPos;

    public ButtonManager[] buttons;

    public float moveSpeed = 5f;

    bool isJump = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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
#endif

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.1f)
            pos.x = 0.1f;

        if (pos.x > 0.9f)
            pos.x = 0.9f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);


        if (buttons[0].isPush)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
            pos.x = Mathf.Clamp(pos.x, -2f, 2f);
        }
        if (buttons[1].isPush)
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
            pos.x = Mathf.Clamp(pos.x, -2f, 2f);
        }
        if (buttons[2].isPush)
        {

        }
        if (buttons[3].isPush)
        {
            if (!isJump)
            {
                JumpTrue();
                isJump = true;
            }
        }
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
