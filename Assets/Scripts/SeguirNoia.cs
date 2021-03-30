using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirNoia : MonoBehaviour
{
    private bool haArribat = false;
    public Collider colliderGrup;
    public GameObject personatge;
    public GameObject desconegut;

    private float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Ha fet trigger: " + other.name);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        haArribat = true;
        personatge = other.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        // Quan surti del collider faré que segueixi a la noia   
        Debug.Log("Update");
        if (haArribat)
        {
            Debug.Log("Personatge: " + personatge.name + " / Target: " + desconegut.name);
            float dist = Vector3.Distance(personatge.gameObject.transform.position, desconegut.transform.position);
            Debug.Log("Distancia: " + dist);
            if (dist > 10f)
            {
                Debug.Log("Seguint a la noia aquesta");
                float dot = Vector3.Dot(personatge.transform.forward, (desconegut.transform.position - personatge.transform.position).normalized);
                if (dot < 0.7f)
                {
                    Debug.Log("Em moc");
                    desconegut.transform.position = Vector3.MoveTowards(desconegut.transform.position, personatge.transform.position, speed * Time.deltaTime);
                }
            }

        }
     
    }
}
