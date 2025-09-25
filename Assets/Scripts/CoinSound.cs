using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSound : MonoBehaviour
{
    public AudioSource coinAudio;

    void PlayCoinSound()
    {
        coinAudio.PlayOneShot(coinAudio.clip);
    }
}
