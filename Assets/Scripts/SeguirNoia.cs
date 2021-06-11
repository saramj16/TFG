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

    public float tiempo = 0f;
    public float tiempoMaxim = 5f;

    private Vector3 posicioIniciDesconegut;

    private float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        final = false;
        haArribat = false;
        posicioIniciDesconegut = desconegut.transform.position;
    }


    private void OnTriggerExit(Collider other)
    {

        if(this.gameObject.transform.tag == colliderGrup.transform.tag)
        {
            //Debug.Log("Tag: " + this.gameObject.transform.tag + " / Collider: " + colliderGrup.transform.tag);
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            
            personatge = other.gameObject;

        }

    }

    public void HaArribat()
    {
        haArribat = true;
    }
    // Update is called once per frame
    void Update()
    {
        // Quan surti del collider faré que segueixi a la noia   
        //Debug.Log("Update");
        if (haArribat)
        {
          //  Debug.Log("Personatge: " + personatge.name + " / Target: " + desconegut.name);
            float dist = Vector3.Distance(personatge.gameObject.transform.position, desconegut.transform.position);
          //  Debug.Log("Distancia: " + dist);
            if (dist > 10f)
            {
                if(final == false)
                {
                    float dot = Vector3.Dot(personatge.transform.forward, (desconegut.transform.position - personatge.transform.position).normalized);
                    if (dot < 0.7f)
                    {
                        Debug.Log("Em moc");
                        desconegut.transform.position = Vector3.MoveTowards(desconegut.transform.position, personatge.transform.position, speed * Time.deltaTime);


                    }
                }
            }

            if(final == true)
            {
                //Se'n torna cap a caseta o fem destroý

                float dist_way = Vector3.Distance(personatge.gameObject.transform.position, desconegut.transform.position);


                if (dist_way > 5f)
                {
                    desconegut.transform.position = Vector3.MoveTowards(desconegut.transform.position, posicioIniciDesconegut, speed * Time.deltaTime);
                }

            } else {
                /*
                //Cada X segons dir alguna cosa
                tiempo += Time.deltaTime;
                if (tiempo >= tiempoMaxim)
                {
                    tiempo = 0;
                    
                    Debug.Log("Guarra");
                }*/
            }

        }
     
    }
}
