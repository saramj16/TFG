using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoadRuta : MonoBehaviour
{
    public GameObject waypointFather;

    public GameObject hora;
    int horaInt;
    int tempsTardaInt;
    public GameObject tempsTardar;

    public GameObject quilometres;
    int kmInt;
    public GameObject metres;
    int metresInt;

    public GameObject panellKm;
    public GameObject panellMetres;



    int waypoints;


    void Start()
    {
        horaInt = int.Parse(hora.gameObject.GetComponent<TextMeshProUGUI>().text);
        tempsTardaInt = int.Parse(tempsTardar.gameObject.GetComponent<TextMeshProUGUI>().text);
        kmInt = int.Parse(quilometres.gameObject.GetComponent<TextMeshProUGUI>().text);
        metresInt = int.Parse(metres.gameObject.GetComponent<TextMeshProUGUI>().text);
        waypoints = waypointFather.transform.childCount;
        panellKm.SetActive(true);
    }

    void Update()
    {
        Vector3 me = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z);
        Vector3 waypoint = new Vector3();
        for(int i = 0; i < waypointFather.transform.childCount; i++)
        {
            waypoint = new Vector3(waypointFather.transform.GetChild(i).transform.position.x, 0, waypointFather.transform.GetChild(i).transform.position.z);
            float dist = Vector3.Distance(me, waypoint);
            if(dist < 60)
            {
                waypointFather.transform.GetChild(i).gameObject.SetActive(false);
                //Debug.Log("Waypoints Actius");
            }
        }
        UpdateHora();
        UpdateDistancia();
    }


    int NumeroWaypointsActius()
    {
        int actius = 0;
        for (int i = 0; i < waypointFather.transform.childCount; i++)
        {
            if(waypointFather.transform.GetChild(i).gameObject.activeSelf == true)
            {
                actius++;
            }
        }
            return actius;
    }

    void UpdateHora()
    {
        if(NumeroWaypointsActius() <= 30)
        {
            //horaInt = int.Parse(hora.gameObject.GetComponent<TextMeshProUGUI>().text);
            int tempsAnterior = tempsTardaInt;
            tempsTardaInt = Mathf.RoundToInt( NumeroWaypointsActius() / 2);
            
            tempsTardar.gameObject.GetComponent<TextMeshProUGUI>().text = tempsTardaInt.ToString();
            if(tempsAnterior != tempsTardaInt) {
                horaInt = int.Parse(hora.gameObject.GetComponent<TextMeshProUGUI>().text);
                horaInt++;
                hora.gameObject.GetComponent<TextMeshProUGUI>().text = horaInt.ToString();
            }
        }
    }

    void UpdateDistancia()
    {
        //Debug.Log("Waypoints: " + waypoints);
        //Debug.Log("Waypoints Actius: " + NumeroWaypointsActius());
        if(waypoints > NumeroWaypointsActius())
        {
            waypoints = NumeroWaypointsActius();
            if (kmInt != 0)
            {
                kmInt = kmInt - 5;
                if(kmInt == 5)
                {
                    quilometres.gameObject.GetComponent<TextMeshProUGUI>().text = "05";
                } else
                {
                    quilometres.gameObject.GetComponent<TextMeshProUGUI>().text = kmInt.ToString();
                }

                panellKm.SetActive(true);
                panellMetres.SetActive(false);
                //Debug.Log("Distància a: " + kmInt);
            } else
            {
                metresInt = metresInt - 50;
                metres.gameObject.GetComponent<TextMeshProUGUI>().text = metresInt.ToString();
                panellMetres.SetActive(true);
                panellKm.SetActive(false);
               // Debug.Log("Distància a: " + metresInt);
            }

        }
    }
}
