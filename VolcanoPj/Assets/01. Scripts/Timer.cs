using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timeText;

    public float defaultTime = 30f;
    public float currentTime;

    public bool isStop = true;
    public bool timeSkill = false;

    public GameObject gameOverPanel;
    public GameObject spawnObj;
    public GameObject topTouch;
    public GameObject bottomTouch;
    public GameObject startPanel;

    public JsonData json;
    public PlayerMove playerMove;
    public ObjSpawner spawner;
    public Menu menu;
    public DataManager dataM;

    void Start() 
    {
        defaultTime += dataM.reinLv[2];
        currentTime = defaultTime;
        gameOverPanel.SetActive(false);
        timeSkill = false;
    }

    void Update()
    {
        
        if(currentTime <= 0)
        {
            gameOverPanel.SetActive(true);
            spawnObj.SetActive(false);
            playerMove.isOver = true;
            json.SaveJData();
            topTouch.SetActive(true);
            bottomTouch.SetActive(true);

            for(int i = 0; i < spawner.dropList.Count; i++)
            {
                Destroy(spawner.dropList[i].gameObject);
            }

            spawner.dropList.Clear();
            Mathf.Clamp(currentTime, 0, int.MaxValue);
        }
        else 
        {
            if(!isStop && !timeSkill)
            {
                currentTime -= Time.deltaTime;
            }
            timeText.text = $"Time : {currentTime:F2}";
        }

        if(isStop)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }

    }

    public void StartGame()
    {
        isStop = !isStop;
        startPanel.SetActive(false);
        menu.isStartMenu = false;
    }
}
