using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public DataManager dataM;

    public void TimeStopBuy()
    {
        dataM.skillSet[0] = true;
    }

    // public void TimeStop()
    // {

    // }
}
