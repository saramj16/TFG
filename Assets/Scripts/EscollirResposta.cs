using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscollirResposta : MonoBehaviour
{

    Button[] buttons = new Button[4];
    public GameObject panelRespostes;
    public VisualMissatge visualMissatge;
    public GameObject panelMissatges;

    void Start()
    {
        Debug.Log("Entra al start de les respostes");
     //   panelMissatges.SetActive(false);
      //  panelRespostes.SetActive(true);
        Cursor.visible = true;
     //   int i = 0;

        for(int i = 0; i < panelRespostes.transform.childCount; i++)
        {
           // Debug.Log("Panel " + panelRespostes.name);
            //Debug.Log("Child " + panelRespostes.transform.GetChild(i).GetComponent<Button>().GetComponentInChildren<Text>().name);
           // panelRespostes.transform.GetChild(i).gameObject.GetComponent<Button>().GetComponent<Text>().text = "Hola";
        }
      /*  foreach (Transform child in panelRespostes.transform)
        {
            //Debug.Log("Entra aqui");
           // buttons[i]= child.GetComponent<Button>();
           // buttons[i].GetComponents<Button>() = child.GetComponents<Text>();
            i++;
        }*/

    }


    public void OmplirOpcions(Respostes r)
    {
        //Start();

        Debug.Log("Entra a posar opcions");


        Cursor.visible = true;

       // Debug.Log("Panel: " + pR);
       // Debug.Log("Panel Child: " + panelRespostes.transform.GetChild(0));
        //Aquesta puta merda peta
    /*    panelRespostes.transform.GetChild(0).GetComponent<Button>().GetComponentInChildren<Text>().text = r.resposta1.ToString();
        panelRespostes.transform.GetChild(1).GetComponent<Button>().GetComponentInChildren<Text>().text = r.resposta2.ToString();
        panelRespostes.transform.GetChild(2).GetComponent<Button>().GetComponentInChildren<Text>().text = r.resposta3.ToString();
        panelRespostes.transform.GetChild(3).GetComponent<Button>().GetComponentInChildren<Text>().text = r.resposta4.ToString();
 

         
        */

    }
    void Update()
    {
        //Falta posar el missatge per pantalla
       /* if (panelRespostes.transform.GetChild(0).GetComponent<Button>().GetComponent<ClickButton>().hanClickat)
        {
            Debug.Log(panelRespostes.transform.GetChild(0).GetComponent<Button>().GetComponent<Text>().text);
            visualMissatge.CreaMissatge("Tu: " + buttons[0].GetComponentInChildren<Text>().text);
            panelMissatges.SetActive(true);
            panelRespostes.SetActive(false);
            Cursor.visible = false;
        }
        if (panelRespostes.transform.GetChild(1).GetComponent<Button>().GetComponent<ClickButton>().hanClickat)
        {
            Debug.Log(panelRespostes.transform.GetChild(1).GetComponent<Button>().GetComponent<Text>().text);
            visualMissatge.CreaMissatge("Tu: " + buttons[1].GetComponentInChildren<Text>().text);
            panelMissatges.SetActive(true);
            panelRespostes.SetActive(false);
            Cursor.visible = false;
        }
        if (panelRespostes.transform.GetChild(2).GetComponent<Button>().GetComponent<ClickButton>().hanClickat)
        {
            Debug.Log(panelRespostes.transform.GetChild(2).GetComponent<Button>().GetComponent<Text>().text);
            visualMissatge.CreaMissatge("Tu: " + buttons[2].GetComponentInChildren<Text>().text);
            panelMissatges.SetActive(true);
            panelRespostes.SetActive(false);
            Cursor.visible = false;
        }
        if (panelRespostes.transform.GetChild(3).GetComponent<Button>().GetComponent<ClickButton>().hanClickat)
        {
            Debug.Log(panelRespostes.transform.GetChild(3).GetComponent<Button>().GetComponent<Text>().text);
            visualMissatge.CreaMissatge("Tu: " + buttons[3].GetComponentInChildren<Text>().text);
            panelMissatges.SetActive(true);
            panelRespostes.SetActive(false);
            Cursor.visible = false;
        }*/
    }

}
