using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{
    public CharacterController controller;

    float speed = 0f;
    float speedNormal = 5f;
    float speedFast = 30f;
    float gravity = -9.81f;

    public bool blockMovment = true;

    Vector3 velocity;

    public GameObject panelDialeg;
    public GameObject panelResposta;

    public bool keysReady;
    
    Animator anim;
    public GameObject keys;
    private void Start()
    {
        keys.gameObject.SetActive(false);
        speed = speedNormal;
        blockMovment = true;
        //Debug.Log("Nom: " + this.transform.GetChild(0).gameObject.name);
        anim = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        
        if (!panelDialeg.activeSelf && !panelResposta.activeSelf)
        {

            if (blockMovment == true)
            {
                float x = Input.GetAxisRaw("Horizontal");
                float y = Input.GetAxisRaw("Vertical");
                
               // Debug.Log("X: " + x);
               // Debug.Log("Y: " + y);

                anim.SetFloat("x", x);
                anim.SetFloat("y", y);

                Vector3 movement = transform.right * x + transform.forward * y;

                controller.Move(movement * speed * Time.deltaTime);

                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    //Debug.Log("Fast");
                    speed = speedFast;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                   // Debug.Log("Lento");
                    speed = speedNormal;
                }

                // Aqui hem d'activar el tema de la noia, de portar les claus a la mà i poder atacar
                if (Input.GetKeyUp(KeyCode.Space))
                {
                    if(keysReady == true){
                        //Activem atac
                        Debug.Log("Ataquem");
                        anim.SetBool("ataca", true);
                        Invoke("AtacFalse", 1.6f); 
                    } else {
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
        } 
        
    }

    public void AtacFalse()
    {
        Debug.Log("JA NO ATAQUEM");
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
        Debug.Log("Pos rip pq tha violat");
    }
}
