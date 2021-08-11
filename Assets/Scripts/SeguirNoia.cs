using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirNoia : MonoBehaviour
{
    private bool haArribat = false;

    public bool final = false;
    public Collider colliderGrup;

    public GameObject personatge;
    public GameObject desconegut;
    private Animator animDesconegut;
    private AudioSource audioSourceDesconegut;

    public float tiempo = 0f;
    public float tiempoMaxim = 4f;

    private Vector3 posicioIniciDesconegut;

    private float speed = 8f;
    Vector3 posicioAntiga;
    float altura;

    // Start is called before the first frame update
    void Start()
    {
        final = false;
        haArribat = false;
        posicioIniciDesconegut = desconegut.transform.position;
        posicioAntiga = desconegut.transform.position;
        animDesconegut = desconegut.gameObject.GetComponent<Animator>();
        audioSourceDesconegut = desconegut.gameObject.GetComponent<AudioSource>();
        altura = desconegut.transform.position.y;
    }


    private void OnTriggerExit(Collider other)
    {
        if(this.gameObject.transform.tag == colliderGrup.transform.tag)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            personatge = other.gameObject;

            if (this.gameObject.transform.tag == "QuartGrup")
            {
                haArribat = true;
            }
        }
    }

    public void HaArribat()
    {
        haArribat = true;
    }
    // Update is called once per frame
    void Update()
    {       
        if (haArribat)
        {
            float dist = Vector3.Distance(personatge.gameObject.transform.position, desconegut.transform.position);

            if (dist > 10f)
            {
                if(final == false)
                {
                    float dot = Vector3.Dot(personatge.transform.forward, (desconegut.transform.position - personatge.transform.position).normalized);
                    if (dot < 0.7f)
                    {
                        desconegut.transform.LookAt(personatge.transform);
                        desconegut.transform.position = Vector3.MoveTowards(desconegut.transform.position, personatge.transform.position, speed * Time.deltaTime);
                        desconegut.transform.position = new Vector3(desconegut.transform.position.x, altura, desconegut.transform.position.z);
                        if (desconegut.transform.position != posicioAntiga)
                        {
                            //Debug.Log("Activa true del parguelas q camina");
                            animDesconegut.SetBool("walking", true);
                            stepSound(audioSourceDesconegut);
                            posicioAntiga = desconegut.transform.position;
                        } else {
                            //Debug.Log("False");
                            animDesconegut.SetBool("walking", false);
                            audioSourceDesconegut.Stop();
                        }

                    }
                    else
                    {
                        //Debug.Log("Esta entrant aqui?");
                        animDesconegut.SetBool("walking", false);
                        audioSourceDesconegut.Stop();
                    }
                }
            } else
            {
                animDesconegut.SetBool("walking", false);
                audioSourceDesconegut.Stop();
            }

            if(final == true)
            {
                float dist_way = Vector3.Distance(personatge.gameObject.transform.position, desconegut.transform.position);
                if (dist_way > 5f)
                {
                    desconegut.transform.LookAt(posicioIniciDesconegut);
                    desconegut.transform.position = Vector3.MoveTowards(desconegut.transform.position, posicioIniciDesconegut, speed * Time.deltaTime);
                    animDesconegut.SetBool("walking", true);
                    stepSound(audioSourceDesconegut);
                } else
                {
                    animDesconegut.SetBool("walking", false);
                    audioSourceDesconegut.Stop();
                }
            } 
        }
    }

    public void stepSound(AudioSource step)
    {
        step.pitch = Random.Range(0.6f, 1.6f);
        if (!step.isPlaying)
        {
            step.Play();
        }

    }
}
