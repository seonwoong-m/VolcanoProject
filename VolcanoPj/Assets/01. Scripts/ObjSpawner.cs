using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjSpawner : MonoBehaviour
{
    public GameObject[] dropObjs;
    float time = 0f;
    void Update()
    {
        time += Time.deltaTime;

        if(time >= 0.5f)
        {
            SpawnObj();
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
