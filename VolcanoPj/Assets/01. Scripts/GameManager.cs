using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject exitPanel;
    public Timer timer;
    public DataManager dataM;

    private bool isTouched = false;
    public bool isEvented = false;

    float touchTime = 0f;
    int touchCount = 0;

    void Awake()
    {
        exitPanel.SetActive(false);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }

    public void OpenGit()
    {
        Application.OpenURL("https://github.com/sunwoong-m/VolcanoProject");
    }

    public void Resume()
    {
        exitPanel.SetActive(false);
        timer.isStop = false;
    }

    public void TouchEvent()
    {
        if(!isTouched) isTouched = true;
        touchCount++;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
            timer.isStop = true;
        }

        if(!isEvented && isTouched)
        {
            touchTime += Time.deltaTime;

            if(touchTime > 3f)
            {
                touchTime = 0f;
                isTouched = false;
            }

            if(touchTime <= 3f && touchCount == 10)
            {
                for(int i = 0; i < dataM.itemAmount.Length; i++)
                {
                    dataM.itemAmount[i] += 50;
                    dataM.amountText[i].text = $"{dataM.itemAmount[i]}";
                }

                isEvented = true;
            }
        }
    }
}
