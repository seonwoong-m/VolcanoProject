using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public string sceneName;

    public void OnClickStart()
    {
        LoadingSceneManager.LoadScene(sceneName);
    }
}
