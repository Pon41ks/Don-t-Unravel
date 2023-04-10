using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private int poolCount = 5;
    [SerializeField] private bool autoExpand = false;
    [SerializeField] private Pipe pipePrefab;
    private const int Chance = 10;
    private const int CoinSpawnLuckNumber1 = 1;
    private const int CoinSpawnLuckNumber2 = 10;

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
        }
        // ReSharper disable once IteratorNeverReturns
    }

    private void CreatePipe()
    {
        var y = Random.Range(-0.9f, 0.9f);
        var rPosition = new Vector3(8, y, 0);
        var rChance = Random.Range(1, Chance);
        var pipe = _pipesPool.GetFreeElement();
        pipe.transform.position = rPosition;
        
        if (rChance is CoinSpawnLuckNumber1 or CoinSpawnLuckNumber2)
        {
            pipe.CreateCoin();
        }
    }
}