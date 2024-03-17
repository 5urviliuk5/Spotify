using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synth : MonoBehaviour
{
    public float frequency;
    public AudioSource source;

    void Start()
    {
        var clip = AudioClip.Create("Sin", 44100 * 3, 1, 44100, false);

        var samples = new float[44100 * 3];
        for (int i = 0; i < samples.Length; i++)
        {
            samples[i] = Mathf.Sin(i / 44000f * 6.28f * frequency);
            samples[i] += Mathf.Sin(i / 44100f * Mathf.PI * 2f * 960);
            samples[i] *= 0.5f;
        }

        clip.SetData(samples, 0);
        source.clip = clip;
        source.Play();
    }
}
