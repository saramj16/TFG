using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirantPersonatge : MonoBehaviour
{
    public bool desactivat;
    // Start is called before the first frame update
    void Start()
    {
        desactivat = false;
    }


    void Update()
    {
        if(desactivat == false)
        {
            LayerMask mask = LayerMask.GetMask("Interaccions");
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.blue, 10f);
                hit.collider.gameObject.GetComponent<MissatgeMirantme>().posarMissatge();
            }
        }

    }
}
