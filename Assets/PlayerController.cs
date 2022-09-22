using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float Fjump = 5F;
    [SerializeField] private float movement = 5F;
    [SerializeField] private SpriteRenderer sr;

    [SerializeField] private Transform groundPoint;
    [SerializeField] private bool isOnGround;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Animator anim;
    [SerializeField] private bool canJump;
    [SerializeField] private Transform playerTransform;
    
    private float _moveInput;

    private void Update()
    {
        CheckCanJump();
        GroundCheck();
        Flip();
        ActivateAnimation();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnJump(InputValue value)
    {
        if (canJump)
        {
            if (value.isPressed)
            {
                rb.AddForce(Fjump * transform.up, ForceMode2D.Impulse);
            }
        }
    }

    private void OnMove(InputValue value)
    {
        _moveInput = value.Get<float>();
    }
    
    private void Move()
    {
        rb.velocity = new Vector2(_moveInput * movement, rb.velocity.y);
    }

    private void Flip()
    {
        if (_moveInput == -1)
        {
            playerTransform.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (_moveInput == 1)
        {
            playerTransform.transform.localScale = Vector3.one;
        }
    }

    private void GroundCheck()
    {
        isOnGround = Physics2D.OverlapCircle(groundPoint.position, .2f, whatIsGround);
    }

    private void CheckCanJump()
    {
        if(isOnGround)
        {
            canJump = true;
        }
        else
        {
            canJump = true;
        }
    }

    private void ActivateAnimation()
    {
        anim.SetBool("Isonground", isOnGround);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x)); 
    }

}

