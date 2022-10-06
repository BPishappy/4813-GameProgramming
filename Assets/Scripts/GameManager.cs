using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Transform LivesText;
    [SerializeField] public int PlayerLives = 3;
    [SerializeField] private PlayerLives playerLives;
    // Simple singleton script. This is the easiest way to create and understand a singleton script.
    
    private void Awake()
    {
        var numGameManager = FindObjectsOfType<GameManager>().Length;

        if (numGameManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        UpdateLives();
    }

    private void Update()
    {
        if(PlayerLives <= 0)
        {
            Destroy(gameObject);
            LoadScene(0);
        }
        if(GetCurrentBuildIndex() == 0)
        {
            LivesText.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            LivesText.gameObject.SetActive(true);
        }
    } 

    public void ProcessPlayerDeath()
    {
        UpdateLives();
        LoadScene(GetCurrentBuildIndex());
    }
    public IEnumerator LoadNextLevel()
    {
        UpdateLives();
        var nextSceneIndex = GetCurrentBuildIndex() + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        yield return new WaitForSeconds(2F);
        SceneManager.LoadScene(nextSceneIndex);

    }

    public int GetCurrentBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    public void LivesReduce()
    {
        PlayerLives -= 1;
    }
    public void LoadScene(int buildindex)
    {
        UpdateLives();
        SceneManager.LoadScene(buildindex);
        DOTween.KillAll();
    }

    public void UpdateLives()
    {
        playerLives.UpdatePlayerLives(PlayerLives);
    }
}
