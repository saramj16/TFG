using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterMovment : MonoBehaviour
{
    public CharacterController controller;

    float speed = 0f;
    float speedNormal = 15f;
    float speedFast = 35f;
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
    public AudioSource breath;

    public GameObject uiMobil;
    public GameObject cameraMiniMapa;

    public Camera cameraMobil;
    public Camera cameraPrincipal;
    public Animator controllerMobil;

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
        cameraPrincipal.gameObject.SetActive(true);
        cameraMobil.gameObject.SetActive(false);
    }

    void Update() {
        UpdateCameraMinimapa();
        if (!panelDialeg.activeSelf && !panelResposta.activeSelf) {
            if (blockMovment == true) {
                Moviment();
                
                ControlVelocitat();
                ControlTempsVelocitat();
                ActivaUIMobil();
                //ControlKeys();
            }
        } else
        {
            DesactivaUIMobil();
        }
    }

    void UpdateCameraMinimapa()
    {
        float y = cameraMiniMapa.transform.position.y;
        cameraMiniMapa.transform.position = new Vector3(this.gameObject.transform.position.x, y, this.gameObject.transform.position.z);
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
                breath.Play();
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
            if (cameraMobil.gameObject.activeSelf == true)
            {
                //Debug.Log("La camera esta activada i s'ha de desactivar");
                controllerMobil.SetBool("treureMobil", false);
                Invoke("DesactivaCameraMobil", 1.2f);
            } else
            {
                //Debug.Log("La camera esta DESACTIVADA");
                uiMobil.SetActive(true);
                cameraMobil.gameObject.SetActive(true);
                cameraPrincipal.gameObject.SetActive(false);
                controllerMobil.SetBool("treureMobil", true);

            }

            
            
            
        }
    }

    void DesactivaCameraMobil()
    {
        uiMobil.SetActive(!uiMobil.activeSelf);
        cameraMobil.gameObject.SetActive(!cameraMobil.gameObject.activeSelf);
        cameraPrincipal.gameObject.SetActive(!cameraPrincipal.gameObject.activeSelf);
    }

    void DesactivaUIMobil()
    {
        cameraMobil.gameObject.SetActive(false);
        cameraPrincipal.gameObject.SetActive(true);
        uiMobil.SetActive(false);

    }

    void Moviment()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("x", x);
        anim.SetFloat("y", y);
      
        Vector3 moviment = transform.right * x + transform.forward * y;
        controller.Move(moviment * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if ( x > 0 || y > 0) {
            stepSound();
        } else {
            if(respostaAmics == false) {
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
        step.pitch = Random.Range(0.8f, 1.8f);
        if (!step.isPlaying)
        {
            step.Play();
        }
        
    }


}
