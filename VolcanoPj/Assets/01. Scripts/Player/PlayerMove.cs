using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Vector2 playerPos;
    private Animator anim;
    private SpriteRenderer sprite;
    private PlayerInput input;
    private PlayerAnimation playerAnimation;
    Transform player;

    public ButtonManager[] buttons;

    public float moveSpeed = 5f;
    public float jumpTime = 0f;
    public float jumpForce = 5f;

    private bool isJump = false;
    public bool isOver = false;
    public bool isBig = false;

    [Header("바닥 감지 관련")]
    public bool isGround;
    public Transform groundChecker;
    public LayerMask whatIsGround;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        input = GetComponent<PlayerInput>();
        playerAnimation = GetComponent<PlayerAnimation>();
        player = gameObject.transform;
    }

    void FixedUpdate()
    {
        float xMove = input.xMove;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x <= 0.08f)
            pos.x = 0.08f;

        if (pos.x >= 0.92f)
            pos.x = 0.92f;

        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if (input.isJump)
        {
            isJump = true;
        }

        if (isOver)
        {
            player.position = new Vector3(0, -2, 0);
            //rigid.gravityScale = 0f;
            rigid.velocity = Vector2.zero;
            isGround = true;
            isJump = false;
            xMove = 0f;
        }
        else
        {
            if (xMove > 0)
            {
                sprite.flipX = false;
            }
            else if (xMove < 0)
            {
                sprite.flipX = true;
            }

            isGround = Physics2D.OverlapCircle(groundChecker.position, 0.1f, whatIsGround);

            if (isJump && isGround)
            {
                rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                playerAnimation.Jump(); // 애니메이션 점프 재생
            }

            isJump = false;

            if (isGround && rigid.velocity.y < 0.1f)
            {
                playerAnimation.JumpEnd(); // 점핑 애니메이션 끝
            }

            rigid.velocity = new Vector2(xMove * moveSpeed, rigid.velocity.y);
        }

        if(isBig)
        {
            player.localScale = new Vector3(2, 2, 1);
        }
        else
        {
            player.localScale = new Vector3(1.7f, 1.7f, 1);
        }

    }
}