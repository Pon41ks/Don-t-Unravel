using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Coin coin;

    private void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x <= -8)
        {
            gameObject.SetActive(false);
        }
    }

    public void CreateCoin()
    {
        coin.gameObject.SetActive(true);
        
        var y = Random.Range(-2f, 0.5f);
        var rPosition = new Vector3(2, y, 0);
        coin.transform.localPosition = rPosition;
    }
}