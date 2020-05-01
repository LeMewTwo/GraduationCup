using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Volume : MonoBehaviour
{
   //Reference to Audio Scource component
    private AudioSource audioSrc;

    //Music volume variable that will be modified by dragging
    //slider knob
    private float musicVolume = 1f;

    void Start()
    {
        //Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
    }

    //Update is called once per team
    void Update()
    {
        //Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = musicVolume;
    }

    //Method that is called by slider game onject 
    //This method takes vol value passed by slider
    //and sets it as musicValue
    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    {
        if(audioSrc.isPlaying)
        {
            return;
        }
        audioSrc.Play();
    }

    public void StopMusic()
    {
        audioSrc.Stop();
    }

}
