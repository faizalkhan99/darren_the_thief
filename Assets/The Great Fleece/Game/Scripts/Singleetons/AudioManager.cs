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
    [SerializeField] AudioClip _bgm;

    public void PlayVooiceOver(AudioClip vo)
    {
        _audio.clip = vo;
        _audio.Play();
    }

    public void PlayBGM()
    {
        if(_bgm == null) _BGM.clip = _bgm;
        _BGM.UnPause();
        _audio.UnPause();
    }
    public void PauseBGM()
    {
        if (_bgm == null) _BGM.clip = _bgm;
        _BGM.Pause();
        _audio.Pause();
    }
}