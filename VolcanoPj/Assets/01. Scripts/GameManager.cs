using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject exitPanel;
    public Timer timer;

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

    public void Resume()
    {
        exitPanel.SetActive(false);
        timer.isStop = false;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            exitPanel.SetActive(true);
            timer.isStop = true;
        }
    }
}
