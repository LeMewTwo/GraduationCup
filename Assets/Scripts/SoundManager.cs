using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //a single instance of SoundManager that can be accessed from any script
    public static SoundManager Instance = null;

    //all sounds in the game, if public then can set them in the Inspector
    public AudioClip bulletFire;
    public AudioClip playerDies;
    public AudioClip enemyDies;

    //audio sources added to the SoundManager to play sound
    private AudioSource soundEffectAudio;

    // Start is called before the first frame update
    void Start()
    {
        //if there is any other SoundManger then destroy it
        if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            Destroy(gameObject);
        }

        AudioSource theSource = GetComponent<AudioSource>();
        soundEffectAudio = theSource;
    }

    //other GameObject can use this to play sounds
    public void PlayOneShot(AudioClip clip)
    {
        soundEffectAudio. PlayOneShot(clip);
    }
}
