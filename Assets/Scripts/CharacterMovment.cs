﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMovment : MonoBehaviour
{
    public CharacterController controller;

    float speed = 0f;
    float speedNormal = 10f;
    float speedFast = 30f;
    float gravity = -9.81f;

    bool activaFast = false;
    bool coolDown = false;
    public float tiempo = 0f;
    public float tiempoMaxim = 5f;

    public Image barra;

    public bool blockMovment = true;

    Vector3 velocity;

    public GameObject panelDialeg;
    public GameObject panelResposta;

    public bool keysReady;

    public bool respostaAmics = false;
    
    Animator anim;
    public GameObject keys;

    AudioSource step;
    public AudioClip walk;
    public AudioClip run;

    public GameObject uiMobil;

    private void Start()
    {
        keys.gameObject.SetActive(false);
        speed = speedNormal;
        blockMovment = true;
        //Debug.Log("Nom: " + this.transform.GetChild(0).gameObject.name);
        anim = this.gameObject.GetComponent<Animator>();
        step = this.gameObject.GetComponent<AudioSource>();
        respostaAmics = false;
        uiMobil.SetActive(false);
    }

    void Update() {
        if (!panelDialeg.activeSelf && !panelResposta.activeSelf) {
            if (blockMovment == true) {
                Moviment();
                
                ControlVelocitat();
                ControlTempsVelocitat();
                //ActualitzaBarra();
                ActivaUIMobil();
                ControlKeys();

            }
        }

    }

    void ControlTempsVelocitat()
    {
        if (activaFast == true)
        {
            tiempo += Time.deltaTime;
            if (tiempo >= tiempoMaxim)
            {
                coolDown = true;
                activaFast = false;
                speed = speedNormal;
            }
        }

        if (coolDown == true)
        {
            tiempo -= Time.deltaTime;
            if(tiempo <= 0)
            {
                coolDown = false;
            }
        } 
    }

    void ActivaUIMobil()
    {
        if (Input.GetKeyUp(KeyCode.M))
        {
            uiMobil.SetActive(!uiMobil.activeSelf);
        }
    }

    void ActualitzaBarra()
    {
      
        barra.rectTransform.sizeDelta = new Vector2(100 -(tiempo*20), 10);
    }
    void Moviment()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //Debug.Log("X: " + x);
        //Debug.Log("Y: " + y);
       
        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
      
        Vector3 movement = transform.right * x + transform.forward * y;

        controller.Move(movement * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        Debug.Log("x and y: " + x + " / " + y);

        if ( x > 0 || y > 0)
        {
            stepSound();
        } else
        {
            //Debug.Log("Stop q no es fa ");
            if(respostaAmics == false)
            {
                step.Stop();
            }

        }
        
    }

    public void StopNoia()
    {
        Debug.Log("Stop noia");
        anim.SetFloat("x", 0);
        anim.SetFloat("y", 0);

        coolDown = true;
        activaFast = false;
        speed = speedNormal;

        step.Stop();
        
    }
    void ControlKeys()
    {
        // Aqui hem d'activar el tema de la noia, de portar les claus a la mà i poder atacar
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (keysReady == true)
            {
                //Activem atac
                Debug.Log("Ataquem");
                anim.SetBool("ataca", true);
                Invoke("AtacFalse", 1.6f);
            }
            else
            {
                keysReady = true;
                anim.SetBool("searchPocket", true);
                //Posem les claus a la mà
                Invoke("SearchFalse", 0.8f);
            }
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (keysReady == true)
            {
                keysReady = false;
                anim.SetBool("searchPocket", true);
                //Posem les claus a la mà
                Invoke("SearchFalse", 0.8f);

            }

        }
    }
    void ControlVelocitat()
    {
 
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
               
                if(tiempo < 5)
                {
                    coolDown = false;
                    activaFast = true;
                    speed = speedFast;
                } else
                {
                    coolDown = true;
                    activaFast = false;
                    speed = speedNormal;
                }
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                coolDown = true;
                activaFast = false;
                speed = speedNormal;
            }




        }
    public void AtacFalse()
    {
        //Debug.Log("JA NO ATAQUEM");
        anim.SetBool("ataca", false);
    }

    public void SearchFalse()
    {
        anim.SetBool("searchPocket", false);
        //ClausVisibles
        if(keysReady == true)
        {
            keys.gameObject.SetActive(true);
        } else
        {
            keys.gameObject.SetActive(false);
        }
        
    }

    public void AcabesMalament()
    {
        SceneManager.LoadScene("Final_Dolent");
        //Debug.Log("Pos rip pq tha violat");
    }

    public void stopStepSound()
    {
        Debug.Log("Stop Step");
        step.Stop();
    }

    public void playStepSound()
    {
        Debug.Log("Activa Step");
        stepSound();
    }

    public void stepSound()
    {
        Debug.Log("Step");

        if (activaFast) {
            step.clip = run;
        } else {
            step.clip = walk;
        }
        step.pitch = Random.Range(0.6f, 1.6f);
        if (!step.isPlaying)
        {
            step.Play();
        }
        
    }
}
