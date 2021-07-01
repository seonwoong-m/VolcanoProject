using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    ///<summary>    ///xml 주석
    ///사용자의 X축 입력값
    ///</summary>
    public float xMove { get; private set; }
    public bool isJump { get; private set; }
    public bool isDash { get; private set; }

    public ButtonManager[]  buttons;
    public SkillManager skillManager;

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

        


        if (buttons[0].isPush)
        {
            xMove = -1f;
        }
        else if (buttons[1].isPush)
        {
            xMove = 1f;
        }
        else
        {
            xMove = 0f;
        }

        if (buttons[2].isPush)
        {
            skillManager.UseSkill();
            buttons[2].isPush = false;
        }
        
        if (buttons[3].isPush)
        {
            isJump = true;
        }
        else
        {
            isJump = false;
        }
    }
}
