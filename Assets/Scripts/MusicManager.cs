using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public AudioSource sourceA;
    public AudioSource sourceB;
    public float fadeDuration = 2.0f;

    private bool isSourceAActive = true;

    public void CrossfadeTo(AudioClip newClip)
    {
        StopAllCoroutines();
        StartCoroutine(FadeRoutine(newClip));
    }

    private IEnumerator FadeRoutine(AudioClip newClip)
    {
        AudioSource activeSource = isSourceAActive ? sourceA : sourceB;
        AudioSource newSource = isSourceAActive ? sourceB : sourceA;

        newSource.clip = newClip;
        newSource.Play();
        newSource.volume = 0;

        float timer = 0;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float t = timer / fadeDuration;
            
            newSource.volume = t;
            activeSource.volume = 1 - t;
            yield return null;
        }

        activeSource.Stop();
        isSourceAActive = !isSourceAActive;
    }
}