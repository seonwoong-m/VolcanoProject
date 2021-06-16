using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropScript : MonoBehaviour
{
    public float minMass;
    public float maxMass;

    public float minSize;
    public float maxSize;
    
    public float damage;
    public int score;
    public int crystal;

    Rigidbody2D dropObj;

    void Awake()
    {
        dropObj = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float r = Random.Range(minMass, maxMass);
        float s = Random.Range(minSize, maxSize);
        gameObject.GetComponent<Transform>().localScale = new Vector3(s * 5, s * 5, 1);
        dropObj.gravityScale = r;
        dropObj.mass = r;
    }

    void OnCollisionEnter2D(Collision2D cols)
    {
        dropObj.gravityScale = 0f;
        dropObj.mass = 0f;

        var component = cols.gameObject.GetComponent<>();

        Destroy(this.gameObject);
    }
}
