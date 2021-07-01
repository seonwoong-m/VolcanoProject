using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public bool isMenu;
    public bool isStatSt;
    public bool isSkillSt;
    public bool isStartMenu;
    public bool isOther;

    public GameObject menuPanel;
    public GameObject statSPanel;
    public GameObject skillSPanel;
    public GameObject btnPanel;
    public GameObject startPanel;
    public GameObject otherPanel;

    public Timer timer;

    void Awake()
    {
        isMenu = false;
        isStatSt = false;
        isSkillSt = false;
        isStartMenu = true;
        isOther = false;

        menuPanel.SetActive(false);
        statSPanel.SetActive(false);
        skillSPanel.SetActive(false);
        btnPanel.SetActive(false);
        startPanel.SetActive(true);
        otherPanel.SetActive(false);
    }

    public void OpenMenu()
    {
        isMenu = !isMenu;
        isStatSt = false;
        isSkillSt = false;
        isOther = false;

        if(!isStartMenu)
        {
            timer.isStop = !timer.isStop;
        }
        else
        {
            return;
        }
    }

    public void OpenStore(int n)
    {
        if(n == 1)
        {
            isStatSt = true;
            isSkillSt = false;
            isOther = false;
        }
        
        if(n == 2)
        {
            isStatSt = false;
            isSkillSt = true;
            isOther = false;
        }
    }

    public void OpenOther()
    {
        isOther = !isOther;
    }

    public void BackMenu()
    {
        isStatSt = false;
        isSkillSt = false;
        isOther = false;
    }

    void Update()
    {
        if(isMenu)
        {
            Time.timeScale = 0f;
            menuPanel.SetActive(true);

            if(isStartMenu)
            {
                startPanel.SetActive(false);
            }
            
            if(isStatSt && !isSkillSt)
            {
                statSPanel.SetActive(true);
                btnPanel.SetActive(false);
                skillSPanel.SetActive(false);
                otherPanel.SetActive(false);
            }
            else if(isSkillSt && !isStatSt)
            {
                statSPanel.SetActive(false);
                btnPanel.SetActive(false);
                skillSPanel.SetActive(true);
                otherPanel.SetActive(false);
            }
            else
            {
                statSPanel.SetActive(false);
                btnPanel.SetActive(true);
                skillSPanel.SetActive(false);
                otherPanel.SetActive(false);
            }

            if(isOther)
            {
                otherPanel.SetActive(true);
                btnPanel.SetActive(false);
            }            
        }
        else
        {
            menuPanel.SetActive(false);

            if(isStartMenu)
            {
                startPanel.SetActive(true);
            }
        }
    }
}