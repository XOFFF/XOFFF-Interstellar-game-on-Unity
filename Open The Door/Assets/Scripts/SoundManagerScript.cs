using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip openCreak, takeKey, backgroundMusic;
    static AudioSource audioSource;

    void Start()
    {
        openCreak = Resources.Load<AudioClip>("OpenCreak");
        takeKey = Resources.Load<AudioClip>("TakeKey");
        backgroundMusic = Resources.Load<AudioClip>("Music");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "creak":
                audioSource.PlayOneShot(openCreak);
                break;
            case "key":
                audioSource.PlayOneShot(takeKey);
                break;
        }
    }
}
 