using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAnimacioProta : MonoBehaviour
{
    public GameObject protagonista;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.activeSelf == true)
        {
            if(protagonista.gameObject.GetComponent<CharacterMovment>().respostaAmics == false)
            {
                protagonista.gameObject.GetComponent<CharacterMovment>().StopNoia();
            }
            
        }
    }
}
