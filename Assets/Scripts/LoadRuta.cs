using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadRuta : MonoBehaviour
{
    public GameObject waypointFather;

    void Update()
    {
        Vector3 me = new Vector3(this.gameObject.transform.position.x, 0, this.gameObject.transform.position.z);
        Vector3 waypoint = new Vector3();
        for(int i = 0; i < waypointFather.transform.childCount; i++)
        {
            waypoint = new Vector3(waypointFather.transform.GetChild(i).transform.position.x, 0, waypointFather.transform.GetChild(i).transform.position.z);
            float dist = Vector3.Distance(me, waypoint);
            if(dist < 10)
            {
                waypointFather.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
