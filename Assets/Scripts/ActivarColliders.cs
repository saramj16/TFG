using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ActivarColliders : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject grup1;
    public GameObject grup4;


    public Collider colliderGrup1;
    public Collider colliderGrup4;
    public Collider colliderFinal;

    public BoxCollider porter;

    private void OnTriggerEnter(Collider other)
    {
      //  Debug.Log("Trigger: " + other.gameObject.tag);

        if(other.gameObject.tag == "EndCollider")
        {
            if(other.gameObject.name == "ColliderGrup1")
            {
                //Debug.Log("Final Primer Grup TRUE");
                grup1.GetComponent<SeguirNoia>().final = true;             
            }

            if (other.gameObject.name == "ColliderGrup4")
            {
                //Debug.Log("Final Quart Grup TRUE");
                grup4.GetComponent<SeguirNoia>().final = true;
            }

            if (other.gameObject.name == "ColliderFinal")
            {
                //Debug.Log("La noia ha arribat a casa");
                SceneManager.LoadScene("Final");
            }
        }

        if(other.gameObject.tag == "SegonGrup")
        {
            other.gameObject.GetComponent<Collider>().enabled = false;
        }

        if (other.gameObject.tag == "TercerGrup")
        {
            other.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    public void DesactivaPorter()
    {
        porter.GetComponent<BoxCollider>().enabled = false;
    }
}
