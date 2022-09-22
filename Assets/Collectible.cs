using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private SoCollectible collectableobject;
    public enum CollectibleType
    {
        Blue,
        Red,
        Green,
        Yellow,
    }
    public CollectibleType collectableType;
    public Powerup powerup;
    public void ChangePlayerColor()
    {
        switch (collectableType)
        {
            case CollectibleType.Blue:
                sr.color = Color.blue;
                break;
            case CollectibleType.Green:
                sr.color = Color.green;
                break;
            case CollectibleType.Red:
                sr.color = Color.red;
                break;
            case CollectibleType.Yellow:
                sr.color = Color.yellow;
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ChangePlayerColor();
            ActivatedPower();
            Destroy(gameObject);
        }
    }
    public void ActivatedPower()
    {
        switch (powerup)
        {
            case Powerup.DoubleJump:
                Debug.Log("CanDoubleJump");
                break;
        }
    }

}
