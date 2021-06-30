using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    DataManager dataM;
    public Timer myTimer;
    public PlayerMove playerMove;

    [Header("스킬 이펙트")]
    public Image frozenPanel;

    [SerializeField]
    private int[] skillPrices = new int[3];
    [SerializeField]
    private Button[] skillBtn = new Button[3];
    [SerializeField]
    private Button[] selectBtn = new Button[3];

    // 0:TimeFreeze 1:Giant 2:Sprint
    public float[] skillDuration = new float[3];
    public float[] skillDelays = new float[3];

    void Awake()
    {
        dataM = GetComponent<DataManager>();
    }

    void Start()
    {
        frozenPanel.gameObject.SetActive(false);
        myTimer.timeSkill = false;
    }

    public void SkillBuy(int n)
    {
        if(!dataM.bSkill[n] && dataM.itemAmount[2] >= skillPrices[n])
        {
            dataM.itemAmount[2] -= skillPrices[n];
            dataM.bSkill[n] = true;
            skillBtn[n].gameObject.SetActive(false);
            selectBtn[n].gameObject.SetActive(true);
            dataM.amountText[2].text = $"{dataM.itemAmount[2]}";
        }
    }

    public void SetSkill(int n)
    {
        if(dataM.bSkill[n])
        {
            for (int i = 0; i < dataM.skillSet.Length; i++)
            {
                dataM.skillSet[i] = false;
            }

            dataM.skillSet[n] = true;
        }
        else
        {
            return;
        }
    }

    public void UseSkill()
    {
        if(dataM.skillSet[0])
        {
            TimeFreeze();
        }
        if(dataM.skillSet[1])
        {
            Giant();
        }
        if(dataM.skillSet[2])
        {
            Sprint();
        }
    }

    void TimeFreeze()
    {
        if(dataM.skillSet[0])
        {
            myTimer.timeSkill = true;
            frozenPanel.gameObject.SetActive(true);
        }
        else
        {
            return;
        }
    }

    void Giant()
    {
        if(dataM.skillSet[1])
        {
            playerMove.isBig = true;
            StartCoroutine(SkillDur(skillDuration[1]));
            playerMove.isBig = false;
        }
        else
        {
            return;
        }
    }

    void Sprint()
    {
        if(dataM.skillSet[2])
        {
            float tempSpeed = playerMove.moveSpeed;
            playerMove.moveSpeed += playerMove.moveSpeed * 0.2f;
            StartCoroutine(SkillDur(skillDuration[2]));
            playerMove.moveSpeed -= tempSpeed * 0.2f;
        }
    }

    void Update()
    {
        if(myTimer.timeSkill)
        {
            Color frozen = frozenPanel.color;

            if(frozenPanel.color.a >= 0)
            {
                float a = frozen.a;
                frozen.a = a - (Time.deltaTime/(skillDuration[0] * 2.5f));
                frozenPanel.color = frozen;
            }
            else
            {
                frozenPanel.color = new Color(0.5f, 0.9f, 1, 0.4f);
                myTimer.timeSkill = false;
                frozenPanel.gameObject.SetActive(false);
            }
        }
    }

    IEnumerator SkillDur(float skillDur)
    {
        yield return new WaitForSeconds(skillDur);
    }
}
