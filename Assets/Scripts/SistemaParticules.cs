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
            GameObject aux = this.gameObject.transform.GetChild(i).gameObject;
            for (int j = 0; j < aux.transform.childCount; j++)
            {
                //Debug.Log("Aux: " + aux.name);
                aux.gameObject.transform.GetChild(j).gameObject.GetComponent<ParticleSystem>().Stop();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            GameObject aux = this.gameObject.transform.GetChild(i).gameObject;
            for (int j = 0; j < aux.transform.childCount; j++)
            {
                float dist = Vector3.Distance(personatge.transform.position, aux.gameObject.transform.GetChild(j).position);

                if (dist > 300f)
                {
                    aux.gameObject.transform.GetChild(j).gameObject.GetComponent<ParticleSystem>().Stop();
                } else {
                    aux.gameObject.transform.GetChild(j).gameObject.GetComponent<ParticleSystem>().Play();
                }
            }            
        }

    }
}
