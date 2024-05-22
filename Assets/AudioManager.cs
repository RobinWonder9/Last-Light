using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

        public AudioClip background;
        public AudioClip missiles;
        public AudioClip wind;


    private void Start()
    {
        musicSource.clip = wind;
        musicSource.Play();
    }

}
