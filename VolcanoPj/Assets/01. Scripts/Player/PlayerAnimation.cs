using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigid;
    private PlayerMove playerMove;

    private readonly int hashXMove = Animator.StringToHash("xMove");
    private readonly int hashYSpeed = Animator.StringToHash("ySpeed");
    private readonly int hashIsGround = Animator.StringToHash("IsGround");
    private readonly int hashIsJumping = Animator.StringToHash("IsJumping");

    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        playerMove = GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat(hashXMove, Mathf.Abs(rigid.velocity.x));
        anim.SetFloat(hashYSpeed, rigid.velocity.y);
        anim.SetBool(hashIsGround, playerMove.isGround);
    }

    public void Jump()
    {
        anim.SetBool(hashIsJumping, true);
    }

    public void JumpEnd()
    {
        anim.SetBool(hashIsJumping, false);
    }
}
