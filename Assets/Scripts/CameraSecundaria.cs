using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSecundaria : MonoBehaviour
{
    public bool desactivat = true;
    public bool conversaAmics;

    public GameObject mainCamera;

    GameObject personatge;
    public GameObject missatges;
    public GameObject respostes;
    public GameObject nameText;



    // Start is called before the first frame update
    void Start()
    {
        conversaAmics = false;
        personatge = null;
        CopiaMainCamera();
    }

    // Update is called once per frame
    void Update()
    {
        MirarSiParlaAlgu();
        if (desactivat == true)
        {
            CopiaMainCamera();

        }
        else
        {
            CopiaMainCamera();

            //Hauriem de fer un LookAt pero Smooth, aixo fa coses rares de moment
            //Quaternion targetRotation = Quaternion.LookRotation(personatge.transform.position - transform.position);
            // Smoothly rotate towards the target point.
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
            //Debug.Log("Personatge: " + personatge.name);
            //Debug.Log("Position: " + personatge.transform.position);

            this.gameObject.transform.rotation = personatge.transform.rotation;

            this.gameObject.transform.position = personatge.transform.position + personatge.transform.forward * 10 + personatge.transform.right * 4;

            this.gameObject.transform.LookAt(personatge.transform);

            // Debug.Log("camera secundaria activada: " + personatge.name);


        }
    }




    void MirarSiParlaAlgu()
    {
        if (conversaAmics == true)
        {
            desactivat = true;
            mainCamera.GetComponent<Camera>().enabled = true;
            personatge = null;

        }
        else
        {
            if (missatges.activeSelf == true)
            {
                desactivat = false;
                mainCamera.GetComponent<Camera>().enabled = false;
                BuscarPersonatgeQueParla();
                //Debug.Log(personatge.name + " esta parlant");

            } else {
                if(respostes.activeSelf == true)
                {
                    desactivat = false;
                    mainCamera.GetComponent<Camera>().enabled = false;
                    personatge = GameObject.Find("/Characters/Tu");
                } else
                {
                    desactivat = true;
                    mainCamera.GetComponent<Camera>().enabled = true;
                    personatge = null;
                }  
            }
        }

    }
    void CopiaMainCamera()
    {
        this.gameObject.transform.position = mainCamera.transform.position;
        this.gameObject.transform.rotation = mainCamera.transform.rotation;
    }

    void BuscarPersonatgeQueParla()
    {

        personatge = GameObject.Find("/Characters/" + nameText.GetComponent<Text>().text);
        //Debug.Log("Ha trobat el personatge: " + nameText.GetComponent<Text>().text);

    }

    void ActivaConversaAmics()
    {
        //Debug.Log("Activada la Conversa per no canviar de camera");
        conversaAmics = true;
    }

    void DesactivaConversaAmics()
    {

        conversaAmics = false;
    }
}