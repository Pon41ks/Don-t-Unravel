using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (transform.position.x <= -8)
        {
            gameObject.SetActive(false);
        }
    }
}