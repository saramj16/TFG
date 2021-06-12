using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosicionaKeys : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject posicioMa;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = posicioMa.transform.position;
        this.gameObject.transform.rotation = posicioMa.transform.rotation;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 12)
        {
            Debug.Log("Collider:" + other.gameObject.name);

            //El tio t'ha de respondre que que fas que estas boja i tal,
            // Si li fas més cops igual acabes malament.
        }
        
    }
}
