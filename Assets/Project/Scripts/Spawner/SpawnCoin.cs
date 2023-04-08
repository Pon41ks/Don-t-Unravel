using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
 
    public GameObject[] pipeEmpties;
    public GameObject coin;
    public int chance = 2;
      
    private void Start()
    {
        pipeEmpties = GameObject.FindGameObjectsWithTag("Enemy");
        
        for (int i = 0; i < pipeEmpties.Length; i++)
        {
            int random = Random.Range(0, chance);            
            if (random == chance - 1)
            {
                SpawnerCoin(pipeEmpties[i].transform.position);
            }
        }
    }
    private void SpawnerCoin(Vector3 emptyPos)
    {
        GameObject go = Instantiate(coin, emptyPos, Quaternion.identity) as GameObject;
    }
}