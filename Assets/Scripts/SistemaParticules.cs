using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaParticules : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject personatge;
    void Start()
    {
        personatge = GameObject.FindGameObjectWithTag("Player");

        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        { 
            this.gameObject.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            float dist = Vector3.Distance(personatge.transform.position, this.gameObject.transform.GetChild(i).position);
           // Debug.Log("Distancia fill " + i + " : " + dist);
            if (dist > 250f)
            {
                this.gameObject.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>().Stop();
            }
            else
            {
                this.gameObject.transform.GetChild(i).gameObject.GetComponent<ParticleSystem>().Play();
            }
        }

    }
}
