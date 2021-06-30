using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public int score;
    public int[] reinLv; // 0:speed 1:
    public int[] itemAmount;

    public Text scoreText;
    public Text[] amountText;
    public Text[] reinLvText;
    
    public bool[] bSkill = new bool[3] { false, false, false };
    public bool[] skillSet = new bool[3] { false, false, false }; // 0:TimeFreeze 1:Giant 2:Sprint

    void Start()
    {
        for (int i = 0; i < itemAmount.Length; i++)
        {
            amountText[i].text = $"{itemAmount[i]}";
        }

        reinLvText[0].text = $"SPEED UP +{reinLv[0]}";
        reinLvText[1].text = $"JUMP UP +{reinLv[1]}";
        reinLvText[2].text = $"TIME UP {reinLv[2]}s";
    }

    public void AddScore(int _score)
    {
        score += _score;

        scoreText.text = $"Score : {score}";
    }

    public void AddDrop()
    {
        itemAmount[0]++;

        amountText[0].text = $"{itemAmount[0]}";
    }

    public void AddFIRE()
    {
        itemAmount[1]++;

        amountText[1].text = $"{itemAmount[1]}";
    }

    public void AddCrystal()
    {
        itemAmount[2]++;

        amountText[2].text = $"{itemAmount[2]}";
    }
}


