using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    [SerializeField] private float jumpForce; //сила толчка
    
    private Animator _animator;
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;

    private Sprite _deadSprite;
    [SerializeField] private SO_Skins skinDatabase; // Список скинов

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Initialize()
    {
        foreach (var skinParameter in skinDatabase.skinsParameters)
        {
            if (skinParameter.skinSprite.name != SaveData.Current.equippedSkin) continue;
            _spriteRenderer.sprite = skinParameter.skinSprite;
            _deadSprite = skinParameter.deadSkinSprite;
        }
    }
    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!ctx.performed) return;
        _rb.velocity = Vector2.up * jumpForce;
        _animator.SetTrigger("onJump");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Score")) GlobalEventManager.AddScore(1);
        if (!collision.CompareTag("Enemy")) return;
        Die();
        GlobalEventManager.SendPlayerDied();
    }
    private void Die()
    {
        _spriteRenderer.sprite = _deadSprite;
    }
}