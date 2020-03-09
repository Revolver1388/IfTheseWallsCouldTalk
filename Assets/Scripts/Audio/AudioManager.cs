﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    Scene thisScene;

    #region Debug Menu
    public Slider music_Volume;
    public Slider SFX_Volume;
    #endregion
    
    #region AudioMixer
    [SerializeField] AudioMixer MainMix;
    [SerializeField] AudioMixerGroup musicGroup;
    [SerializeField] AudioMixerGroup sfxGroup;
    #endregion

    #region AudioSources
    [SerializeField] AudioSource levelMusic;
    [SerializeField] AudioSource sfxSource;
    #endregion

    #region Audio Clips
    public SfxClip[] sfx;
    public LevelMusic[] lvl_Music;
    #endregion

    readonly float levelMusicDelay = 1.3f;
    readonly float battleMusicDelay = 2f;

    private void Awake()
    {
        levelMusic = GameObject.FindGameObjectWithTag("m_Level").GetComponent<AudioSource>();
        sfxSource = GameObject.FindGameObjectWithTag("sfx").GetComponent<AudioSource>();
    }

    private void Start()
    {
        thisScene = SceneManager.GetActiveScene();
        StartCoroutine(PlayMusic("Normal"));
    }

    public IEnumerator PlayMusic(string clipName)
    {
        StopMusic();
        yield return new WaitForSeconds(levelMusicDelay);
        foreach(LevelMusic song in lvl_Music) { if (song.name == clipName) levelMusic.clip = song.clip; levelMusic.Play(); }
        levelMusic.Play();
    }


    public void PlayOneShotByName(string sound)
    { foreach (SfxClip clip in sfx) if (clip.name == sound) sfxSource.PlayOneShot(clip.clip); }

    void FadeMusic()
    {
     //   levelMusic.
    }

    public void StopMusic()
    {
        levelMusic.Stop();
    }

    [System.Serializable]
    public struct BattleType { public string name; public AudioClip clip; }

    [System.Serializable]
    public struct LevelMusic { public string name; public AudioClip clip; }

    [System.Serializable]
    public struct SfxClip { public string name; public AudioClip clip; }
}
