using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraSecundaria : MonoBehaviour
{
    public bool desactivat = true;
    public bool conversaAmics;
    public bool conversaEnCurs = false;
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
        //CopiaMainCamera();
    }

    // Update is called once per frame
    void Update()
    {
        MirarSiParlaAlgu();
        if (desactivat == true) {
            ApagarLlum();
            //CopiaMainCamera();
        }
        else
        {

            this.gameObject.transform.rotation = personatge.transform.rotation;

            this.gameObject.transform.position = personatge.transform.position + personatge.transform.forward * 10 + personatge.transform.right * 4;

            this.gameObject.transform.LookAt(personatge.transform);

            //Activar les llums del personatge
            EncendreLlum();
        }
    }




    void MirarSiParlaAlgu()
    {
        if (conversaAmics == true)
        {
            desactivat = true;
            mainCamera.GetComponent<Camera>().enabled = true;
            ApagarLlum();
            personatge = null;

        }
        else
        {
            if (conversaEnCurs == true)
            {
                desactivat = false;
                mainCamera.GetComponent<Camera>().enabled = false;
                BuscarPersonatgeQueParla();
                //Debug.Log(personatge.name + " esta parlant");

            } else {
                //Debug.Log("Desactiva la camera");
                desactivat = true;
                mainCamera.GetComponent<Camera>().enabled = true;
                ApagarLlum();
                personatge = null;

            }
        }

    }


    public void ApagarLlum()
    {
        if (personatge != null) {
            if (personatge.transform.childCount > 0) {
                personatge.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    public void EncendreLlum()
    {
        if (personatge != null) {
            if (personatge.transform.childCount > 0) {
                personatge.transform.GetChild(0).gameObject.SetActive(true);
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
        if(personatge != null){
            ApagarLlum();
        }
        personatge = GameObject.Find("/Characters/" + nameText.GetComponent<Text>().text);
        EncendreLlum();
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

    void ActivaConversaEnCurs()
    {
        conversaEnCurs = true;
    }

    void DesactivaConversaEnCurs()
    {
        conversaEnCurs = false;
    }
}