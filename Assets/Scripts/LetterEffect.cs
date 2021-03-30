using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LetterEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public string text;
    private string currentText = "";

    void Start()
    {
        StartCoroutine(mostraText());
    }

    IEnumerator mostraText()
    {
        for(int i = 0; i < text.Length+1; i++)
        {
            currentText = text.Substring(0, i);
            this.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = currentText;

            if (i == text.Length-1)
            {
                //Debug.Log("Entra a destruir el missatge");
                Destroy(this.gameObject, 3f);
            } else {
                yield return new WaitForSeconds(delay);
            }
                            
        }
    }
}
