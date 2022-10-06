using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private const string PlayerTag = "Player";

    private GameManager _gameManager;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        AudioManage.instance.SoundEffect(7); 
        if (!col.CompareTag(PlayerTag)) return;
        if (_gameManager.GetCurrentBuildIndex() < 3)
        {
            StartCoroutine(_gameManager.LoadNextLevel());
        }
        else
        {
            _gameManager.LoadScene(1);
        }
}

}