using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Missatges : MonoBehaviour
{
    public List<string> estadistiques;

    public TextMeshPro textPro;

    private int nEstadistica;
    private int maxEstadistica;
    public bool escriu;
    public bool haAcabat;

    public float delay = 0.1f;
    public string text;
    private string currentText = "";
    void Start()
    {
        nEstadistica = 0;
        maxEstadistica = estadistiques.Count;
        textPro.text = "";
        escriu = true;
        haAcabat = false;
    }

    void Update()
    {
        if (escriu)
        {
            text = estadistiques[nEstadistica];
            StartCoroutine(mostraText());
        }

        if (Input.GetMouseButtonDown(0))
        {
            NextMissatge();
        }
    }

    IEnumerator mostraText()
    {
        escriu = false;
        for (int i = 0; i < text.Length + 1; i++)
        {
            currentText = text.Substring(0, i);
            textPro.gameObject.GetComponent<TMPro.TextMeshPro>().text = currentText;

            if (i == text.Length - 1)
            {
                //Debug.Log("Entra a destruir el missatge");
                haAcabat = true;
                //Destroy(this.gameObject, 3f);
            }
            else
            {
                yield return new WaitForSeconds(delay);
            }

        }
    }

    public void NextMissatge() 
    {
        if (escriu == false && haAcabat == true)
        {
            if (nEstadistica + 1 == maxEstadistica)
            {
                //Final del joc
                
            }
            else
            {
                haAcabat = false;
                escriu = true;
                nEstadistica++;

            }
        }
    }

}
