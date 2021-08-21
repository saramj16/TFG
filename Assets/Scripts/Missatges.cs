using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class Missatges : MonoBehaviour
{
    public List<string> estadistiques;

    public TextMeshPro textPro;

    public GameObject panellFinal;

    private int nEstadistica;
    private int maxEstadistica;
    public bool escriu;
    public bool haAcabat;

    public float delay = 0.1f;
    public string text;
    private string currentText = "";

    float frequencyActivarEfecte = 3f;
    float durationEffect = 1f;
    bool efecteActiu = false;
    public float temps = 0.0f;

    float base1 = 0.0f; // start
    float amplitude = 1.0f; // amplitude of the wave
    public PostProcessVolume ppv;
    Bloom bloomLayer;

    void Start()
    {
        nEstadistica = 0;
        maxEstadistica = estadistiques.Count;
        textPro.text = "";
        escriu = true;
        haAcabat = false;
        ppv.profile.TryGetSettings(out bloomLayer);
    }

    void Update()
    {
        if (escriu)
        {
            text = estadistiques[nEstadistica];
            StartCoroutine(mostraText());
        }

        if (Input.GetMouseButtonDown(0))
        {
            NextMissatge();
        }

        if(panellFinal.activeSelf == true)
        {
            Timer();

            if (efecteActiu)
            {
                float evalWave = EvalWave();

                bloomLayer.intensity.value = evalWave;
            }
        }
    }

    IEnumerator mostraText()
    {
        escriu = false;
        for (int i = 0; i < text.Length + 1; i++)
        {
            currentText = text.Substring(0, i);
            textPro.gameObject.GetComponent<TMPro.TextMeshPro>().text = currentText;

            if (i == text.Length - 1)
            {
                //Debug.Log("Entra a destruir el missatge");
                haAcabat = true;
                //Destroy(this.gameObject, 3f);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }

        }
    }

    public void NextMissatge() 
    {
        if (escriu == false && haAcabat == true)
        {
            if (nEstadistica + 1 == maxEstadistica)
            {
                //Final del joc
                for(int i = 0; i < this.gameObject.transform.childCount; i++)
                {
                    this.gameObject.transform.GetChild(i).gameObject.SetActive(false);
                    this.gameObject.GetComponent<AudioSource>().Stop();
                }
                panellFinal.SetActive(true);
                panellFinal.gameObject.GetComponent<AudioSource>().Play();
            }
            else
            {
                haAcabat = false;
                escriu = true;
                nEstadistica++;

            }
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

}
