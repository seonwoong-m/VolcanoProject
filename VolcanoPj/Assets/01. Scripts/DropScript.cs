using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D cols)
    {
        Destroy(this.gameObject);
    }
}
