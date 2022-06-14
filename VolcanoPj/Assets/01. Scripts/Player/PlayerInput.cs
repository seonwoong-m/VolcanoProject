using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    ///<summary>
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
        buttons[0].isPush = (Input.GetKey(KeyCode.LeftArrow))  ? true : false;
        buttons[1].isPush = (Input.GetKey(KeyCode.RightArrow)) ? true : false;
        buttons[2].isPush = (Input.GetKey(KeyCode.UpArrow))    ? true : false;
        buttons[3].isPush = (Input.GetKey(KeyCode.Space))      ? true : false;
#endif

        if (buttons[0].isPush) { xMove = -1f; }
        else if (buttons[1].isPush) { xMove = 1f; }
        else { xMove = 0f; }

        if (buttons[2].isPush)
        {
            skillManager.UseSkill();
            buttons[2].isPush = false;
        }
        
        isJump = (buttons[3].isPush) ? true : false;
    }
}
