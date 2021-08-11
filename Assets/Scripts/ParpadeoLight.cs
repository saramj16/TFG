using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParpadeoLight : MonoBehaviour
{
    public Light llum;
    public float tiempo = 0f;
    public float tiempoMax = 1f;
    public float tiempoParpadeo = 0.1f;
    bool parpadeo = false;
    int numParpadeo = 0;
    int numMaxParpadeo = 6;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            tiempo += Time.deltaTime;

            if (tiempo >= tiempoParpadeo)
            {
                if (numParpadeo == numMaxParpadeo)
                {
                    //Encenem la llum
                    llum.gameObject.SetActive(true);
                    parpadeo = false;
                    numParpadeo = 0;
                    tiempo = 0;
                }
                else
                {
                    //Contrari de si la llum està oberta o tancada
                    bool estat = llum.gameObject.activeSelf;
                    llum.gameObject.SetActive(!estat);
                    numParpadeo++;
                    tiempo = 0;
                }
            }
            else
            {
                if (tiempo >= tiempoMax)
                {
                    tiempo = 0;
                    //Activem el parpadeo
                    parpadeo = true;

                }
            }

       
    }
}
