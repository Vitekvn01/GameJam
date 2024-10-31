using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : SingletonBase<AudioController>
{
    [SerializeField] public AudioSettings AudioSettings;

    private AudioSource _audioSource;

    protected override void Awake()
    {
        base.Awake();
        LoadAudioSettings();
    }

    void Start()
    {
       LoadAudioSettings();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.spatialBlend = 0;
        _audioSource.Play();
    }

    [SerializeField] private AudioMixer MusicMixer;

    [SerializeField] private AudioMixer EffectMixer;

    public void LoadAudioSettings()
    {
        SetEffectVolume(PlayerPrefs.GetFloat("EffectVolume", 0));
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0));
    }

    public void SetEffectVolume(float Value)
    {
        EffectMixer.SetFloat("MasterVolume", Value);
        PlayerPrefs.SetFloat("EffectVolume", Value);
    }

    public void SetMusicVolume(float Value)
    {
        MusicMixer.SetFloat("MasterVolume", Value);
        PlayerPrefs.SetFloat("MusicVolume", Value);
    }

    public void SoundOff()
    {
        Debug.Log("SoundOFF");
        EffectMixer.SetFloat("MasterVolume", -80);
        MusicMixer.SetFloat("MasterVolume", -80);
    }

    public void EffectSoundOff()
    {
        EffectMixer.SetFloat("MasterVolume", -80);
        Debug.Log("EffectSoundOff");
    }

    public void MusicSoundOff()
    {
        MusicMixer.SetFloat("MasterVolume", -80);
        Debug.Log("MusicSoundOff");
    }

    private void OnDestroy()
    {
        Destroy(gameObject);
    }
}
