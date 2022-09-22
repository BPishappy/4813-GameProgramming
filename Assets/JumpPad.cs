using UnityEngine;

public class JumpPad : MonoBehaviour

{
    [SerializeField] private Animator anim;
    private float bounce = 20F;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce,ForceMode2D.Impulse);
            anim.SetTrigger("Bounce");
        }
    }
    
}
