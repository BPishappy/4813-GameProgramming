using UnityEngine;

public class AudioManage : MonoBehaviour
{
    public static AudioManage instance;

    public AudioSource[] soundEffects;

    private void Awake()
    {
        instance = this;
    }

    public void PlayerSFX(int soundToPlay)
    {
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].Play();
    }
}