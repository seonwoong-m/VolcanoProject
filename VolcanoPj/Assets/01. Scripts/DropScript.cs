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

    public float time;
    public int score;

    Rigidbody2D dropObj;
    DataManager dataM;
    Timer timer;
    ObjSpawner objSpawner;

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
        dataM = FindObjectOfType<DataManager>();
        timer = FindObjectOfType<Timer>();
        objSpawner = FindObjectOfType<ObjSpawner>();
    }

    void OnCollisionEnter2D(Collision2D cols)
    {
        dropObj.gravityScale = 0f;
        dropObj.mass = 0f;

        if (cols.gameObject.CompareTag("PLAYER"))
        {
            if (gameObject.CompareTag("DROP"))
            {
                dataM.AddDrop();
            }
            else if (gameObject.CompareTag("FIRE"))
            {
                dataM.AddFIRE();
            }
            else if (gameObject.CompareTag("CRYSTAL"))
            {
                dataM.AddCrystal();
            }

            dataM.AddScore(score);
            timer.currentTime += time;
        }
        else
        {
            timer.currentTime -= 0.1f;
        }

        objSpawner.CheckList(gameObject);
        Destroy(this.gameObject);
    }
}
