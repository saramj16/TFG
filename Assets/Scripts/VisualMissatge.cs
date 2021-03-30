using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualMissatge : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefabMissatge;
    public Transform gridPanel;
    //public GameObject panel;

    void Start()
    {
        //panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (gridPanel.childCount > 0)
        {
            panel.SetActive(true);
           
        } else
        {
            panel.SetActive(false);
        }
        **/
    }

    public void CreaMissatge(string m)
    {

        //Debug.LogError(m);
        prefabMissatge.GetComponent<LetterEffect>().text = m;

        GameObject go;
		go = Instantiate(prefabMissatge, new Vector3(35, -90, 0),Quaternion.identity) as GameObject;
        go.transform.SetParent(gridPanel);
        //Destroy(go, 10f);

    }
}
