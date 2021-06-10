using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public Image hpBar;

    public float maxHp;
    public float hp;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("DROP"))
        {
            float damage = other.gameObject.GetComponent<DropScript>().damage;

            hp -= damage;

            hpBar.fillAmount = hp / maxHp;
        }
    }
}
