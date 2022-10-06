using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    public void StartGame(int buildindex)
    {
        SceneManager.LoadScene(buildindex);
        AudioManage.instance.SoundEffect(4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
}
