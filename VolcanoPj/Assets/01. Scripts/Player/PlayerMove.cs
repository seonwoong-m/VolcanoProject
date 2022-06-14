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
    private Transform player;

    public DataManager dataM;

    public ButtonManager[] buttons;

    public float moveSpeed = 5.0f;
    public float tempSpeed = 0.0f;
    public float jumpTime  = 0.0f;
    public float jumpForce = 5.0f;

    private bool isJump = false;
    public bool isOver = false;
    public bool isBig = false;
    public bool isSprint = false;

    [Header("바닥 감지 관련")]
    public bool isGround;
    public Transform groundChecker;
    public LayerMask whatIsGround;

    private void Awake()
    {
        InitValue();
    }

    private void Start()
    {
        moveSpeed = moveSpeed  + (dataM.reinLv[0] * 0.05f);
        tempSpeed = moveSpeed;
        jumpForce = jumpForce + (dataM.reinLv[1] * 0.03f);
    }

    public void InitValue()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        input = GetComponent<PlayerInput>();
        playerAnimation = GetComponent<PlayerAnimation>();
        player = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        float xMove = input.xMove;

        moveSpeed = (isSprint) ? tempSpeed * 1.2f : tempSpeed;

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x <= 0.08f) pos.x = 0.08f;
        if (pos.x >= 0.92f) pos.x = 0.92f;

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
            sprite.flipX = (xMove < 0) ? true : false;

            isGround = Physics2D.OverlapCircle(groundChecker.position, 0.1f, whatIsGround);

            if (isJump && isGround)
            {
                rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                playerAnimation.Jump(); // 애니메이션 점프 재생
            }

            isJump = false;

            if (isGround && rigid.velocity.y < 0.1f) { playerAnimation.JumpEnd(); // 점핑 애니메이션 끝 }

            rigid.velocity = new Vector2(xMove * moveSpeed, rigid.velocity.y);
        }

        player.localScale = (isBig) ? new Vector3(2f, 2f, 1f) : new Vector3(1.7f, 1.7f, 1f);
    }
    }
}