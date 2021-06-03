using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBtn : MonoBehaviour
{
    public void OnClickStart()
    {
        LoadingSceneManager.LoadScene("MainScene");
    }
}
