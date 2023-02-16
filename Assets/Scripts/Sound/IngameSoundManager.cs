using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameSoundManager : MonoBehaviour
{
    public List<AudioClip> sounds = new List<AudioClip>();
    public AudioSource source;

    private AudioSource onDestroySource;

    private void Start()
    {
        onDestroySource = GameObject.FindWithTag("OneShotAudioSource").GetComponent<AudioSource>();
    }

    public void playAudio(AudioClip clip)
    {
        source.clip = clip;
        source.PlayOneShot(source.clip);
    }

    public void playAudioOnDestroy(AudioClip clip)
    {
        onDestroySource.clip = clip;
        onDestroySource.PlayOneShot(onDestroySource.clip);
    }
}
