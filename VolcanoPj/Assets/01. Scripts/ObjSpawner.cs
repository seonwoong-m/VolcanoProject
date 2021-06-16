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
        randTime = Random.Range(0.8f, 1.2f);
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= randTime)
        {
            SpawnObj();
            randTime = Random.Range(0.7f, 1f);
            time = 0f;
        }
    }

    void SpawnObj()
    {
        int r = Random.Range(0, 10);
        float randomX = Random.Range(-2.2f, 2.2f);

        switch (r)
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                Instantiate(dropObjs[0], new Vector2(randomX, transform.position.y), Quaternion.Euler(0f, 0f, 270f));
                break;
            case 6:
            case 7:
            case 8:
                Instantiate(dropObjs[1], new Vector2(randomX, transform.position.y), Quaternion.Euler(0f, 0f, 270f));
                break;
            case 9:
                Instantiate(dropObjs[2], new Vector2(randomX, transform.position.y), Quaternion.Euler(0f, 0f, 270f));
                break;
        }
    }
}
