using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public GameObject[] dropObjs;
    float time = 0f;
    float randTime;

    void Start()
    {
        randTime = Random.Range(0.7f, 1f);
    }

    void Update()
    {
        time += Time.deltaTime;

        if(time >= randTime)
        {
            SpawnObj();
            randTime = Random.Range(0.7f, 1f);
            time = 0f;
        }
    }

    void SpawnObj()
    {
        int r = Random.Range(0, dropObjs.Length);
        float randomX = Random.Range(-2.2f, 2.2f);

        Instantiate(dropObjs[r], new Vector2(randomX, transform.position.y), Quaternion.Euler(0f, 0f, 270f));
    }
}
