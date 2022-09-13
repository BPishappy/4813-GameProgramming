using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float _Fjump = 5f;
    [SerializeField] private float _movement = 5f;
    [SerializeField] private SpriteRenderer sr;

    private float _moveInput;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(_moveInput * _movement, rb.velocity.y);
    }

    private void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            rb.AddForce(_Fjump * transform.up, ForceMode2D.Impulse);
        }
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
    }
}

