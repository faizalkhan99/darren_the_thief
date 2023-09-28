using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance
    {
        get
        {
            if(_instance == null)
                {
                    Debug.LogError("Audio manager is NULL!");
                }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    [SerializeField] AudioSource _audio;
    [SerializeField] AudioSource _BGM;

    public void PlayVooiceOver(AudioClip vo)
    {
        _audio.clip = vo;
        _audio.Play();
    }

    public void PlayBGM(AudioClip bgm)
    {
        _BGM.clip = bgm;
        _BGM.UnPause();
    }
    public void PauseBGM(AudioClip bgm)
    {
        _BGM.clip = bgm;
        _BGM.Pause();
    }

}
