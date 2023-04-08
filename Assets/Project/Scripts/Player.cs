using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce; //сила толчка
    
    private Animator _animator;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        
        Time.timeScale = 1; 
    }
    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        _rb.velocity = Vector2.up * jumpForce;
        _animator.SetTrigger("onJump");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score")) GlobalEventManager.AddScore(1);
        if (!collision.CompareTag("Enemy")) return;
        _animator.SetTrigger("Die");
        GlobalEventManager.SendPlayerDied();
    }
}