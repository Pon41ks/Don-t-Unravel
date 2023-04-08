using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private int poolCount = 5;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Pipe pipePrefab;
    // [SerializeField] private Coin coin;
    // private const int Chance = 10;

    private PoolMono<Pipe> _pipesPool;

    private void Start()
    {
        _pipesPool = new PoolMono<Pipe>(pipePrefab, poolCount, transform) { AutoExpand = autoExpand };
        StartCoroutine(Spawner());
    }
    private IEnumerator Spawner()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.9f);
            CreatePipe();
            // int random = Random.Range(0, Chance);
            //
            // if (random == 1)
            // {
            //     Coin newCoin = Instantiate(coin, new Vector3(2, rand, 0), Quaternion.identity);
            //     newCoin.transform.SetParent(newPipe.transform);
            // }
            // Destroy(newPipe, 10);
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private void CreatePipe()
    {
        var y = Random.Range(-1f, 1f);
        var rPosition = new Vector3(8, y, 0);
        var pipe = _pipesPool.GetFreeElement();
        pipe.transform.position = rPosition;
    }
}