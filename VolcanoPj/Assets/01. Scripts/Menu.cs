using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    bool isMenu = false;
    bool isStatSt = false;
    public bool isStartMenu = true;

    public GameObject menuPanel;
    public GameObject storePanel;
    public GameObject btnPanel;
    public GameObject startPanel;

    public Timer timer;

    public void OpenMenu()
    {
        isMenu = !isMenu;
        isStatSt = false;
        timer.isStop = !timer.isStop;
    }

    public void OpenStore()
    {
        isStatSt = true;
    }

    public void BackMenu()
    {
        isStatSt = false;
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
            
            if(isStatSt)
            {
                storePanel.SetActive(true);
                btnPanel.SetActive(false);
            }
            else
            {
                storePanel.SetActive(false);
                btnPanel.SetActive(true);
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
