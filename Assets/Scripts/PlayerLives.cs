using UnityEngine;
using TMPro;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    public void UpdatePlayerLives(int lives)
    {
        scoreText.text = $"Lives: {lives}";
    }
}

