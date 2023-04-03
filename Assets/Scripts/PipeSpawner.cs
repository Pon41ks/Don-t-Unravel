using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] GameObject Pipes;
    public GameObject Coin;
    private int chance = 10;
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.9f);
            float rand = Random.Range(-1f, 1f);            
            GameObject newPipe =  Instantiate(Pipes, new Vector3(2, rand, 0), Quaternion.identity);
            int random = Random.Range(0, chance);
  
            if (random == 1)
            {
                GameObject newCoin = Instantiate(Coin, new Vector3(2, rand, 0), Quaternion.identity);
                newCoin.transform.SetParent(newPipe.transform);
            }
            Destroy(newPipe, 10);

            
        }
    }
   
}
