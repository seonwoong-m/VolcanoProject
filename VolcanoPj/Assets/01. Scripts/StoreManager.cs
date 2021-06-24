using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public DataManager dataM;
    public PlayerMove playerMove;
    public Timer timer;

    public Text[] costText;

    int speedCost = 50;
    int jumpCost = 100;
    int timeCost = 30;

    void Start()
    {
        costText[0].text = $"{speedCost} DROPS";
        costText[1].text = $"{jumpCost} DROPS";
        costText[2].text = $"{timeCost} FIRES";
    }

    public void SpeedUp()
    {
        if(dataM.itemAmount[0] >= speedCost && dataM.reinLv[0] <= 30)
        {
            dataM.reinLv[0]++;
            dataM.itemAmount[0] -= speedCost;
            playerMove.moveSpeed += playerMove.moveSpeed * 0.05f;
            speedCost += (int)(speedCost * 0.3f);

            costText[0].text = $"{speedCost} DROPS";
            dataM.amountText[0].text = $"{dataM.itemAmount[0]}";
            dataM.reinLvText[0].text = $"SPEED UP +{dataM.reinLv[0]}";
        }
        else
        {
            return;
        }
    }

    public void JumpUp()
    {
        if(dataM.itemAmount[0] >= jumpCost)
        {
            dataM.reinLv[1]++;
            dataM.itemAmount[0] -= jumpCost;
            playerMove.jumpForce += playerMove.jumpForce * 0.03f;
            speedCost += (int)(jumpCost * 0.2f);

            costText[1].text = $"{jumpCost} DROPS";
            dataM.amountText[0].text = $"{dataM.itemAmount[0]}";
            dataM.reinLvText[1].text = $"JUMP UP +{dataM.reinLv[1]}";
        }
        else
        {
            return;
        }
    }

    public void TimeUp()
    {
        if(dataM.itemAmount[1] >= timeCost)
        {
            dataM.reinLv[2] += 2;
            dataM.itemAmount[1] -= timeCost;
            timer.defaultTime += 2f;
            timeCost += (int)(timeCost * 0.2f);

            costText[2].text = $"{timeCost} FIRES";
            dataM.amountText[1].text = $"{dataM.itemAmount[1]}";
            dataM.reinLvText[2].text = $"TIME UP +{dataM.reinLv[2]}s";
        }
        else
        {
            return;
        }
    }
}
