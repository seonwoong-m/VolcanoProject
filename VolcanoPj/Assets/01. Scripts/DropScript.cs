using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropScript : MonoBehaviour
{
    void Start()
    {
        float r = Random.Range(0.3f, 0.5f);
        gameObject.GetComponent<Transform>().localScale = new Vector3(r * 5, r * 5, 1);
        gameObject.GetComponent<Rigidbody2D>().gravityScale = r;
        gameObject.GetComponent<Rigidbody2D>().mass = r;
    }

    void OnCollisionEnter2D(Collision2D cols)
    {
        Destroy(this.gameObject);
    }
}
