using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;



public class FlickerLight : MonoBehaviour
{

    float base1 = 0.0f; // start
    float amplitude = 1.0f; // amplitude of the wave


    public float frequencyActivarEfecte = 3f;
    float durationEffect = 1f;
    bool efecteActiu = false;
    public float temps = 0.0f;


    public PostProcessVolume ppv;
    Bloom bloomLayer;

    public AudioClip ambient;
    public AudioClip flicker;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        ppv.profile.TryGetSettings(out bloomLayer);
        efecteActiu = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Timer
        Timer();
        ActivaSons();
        if (efecteActiu)
        {
            float evalWave = EvalWave();

            bloomLayer.intensity.value = evalWave;
        }

    }

    public float EvalWave()
    {
        float y;

        y = 1 - (Random.value * 5);

        return (y * amplitude) + base1;
    }

    public void Timer()
    {
        temps += Time.deltaTime;
        if (efecteActiu == false)
        {
            if (temps >= frequencyActivarEfecte)
            {
                efecteActiu = true;
                temps = 0;
            }
        }
        else
        {
            if (temps >= durationEffect)
            {
                efecteActiu = false;
                temps = 0;
                bloomLayer.intensity.value = 1.25f;
            }
        }

 

    }

    public void ActivaSons()
    {

        if (efecteActiu)
        {
            audioSource.clip = flicker;
        } else
        {
            audioSource.clip = ambient;
        }
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
      
    }
}


