using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource masterSource;
    public AudioClip jumpSound;
    public AudioClip coinSound;

    public void PlayJumpSound()
    {
        masterSource.PlayOneShot(jumpSound);
    }
    public void PlayCoinSound()
    {
        masterSource.PlayOneShot(coinSound);
    }

    
}

