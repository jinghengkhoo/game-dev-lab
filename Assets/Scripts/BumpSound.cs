using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumpSound : MonoBehaviour
{
    public AudioSource bumpAudio;

    void PlayBumpSound()
    {
        bumpAudio.PlayOneShot(bumpAudio.clip);
    }
}
