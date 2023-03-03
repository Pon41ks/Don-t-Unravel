using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject Pipes;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            float rand = Random.Range(-1f, 1f);
            GameObject newPipe =  Instantiate(Pipes, new Vector3(2, rand, 0), Quaternion.identity);
            Destroy(newPipe, 10);
            
        }
    }
  
}
