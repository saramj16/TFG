using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutMessage : MonoBehaviour
{
    public GameObject target;
    public List<Missatge> missatges;
    private float currentTime = 0;
    public VisualMissatge vm;
    public bool isEnter = false;
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(target.gameObject.transform.position, transform.position);
        
        currentTime += Time.deltaTime;
        if (dist < 20f)
        {
            if(isEnter == false)
            {
                //Debug.Log(this.name + ": " + missatges[random].tipus);
                currentTime = 0;
                isEnter = true;
                int random = Random.Range(0, missatges.Count);
                vm.CreaMissatge(this.name + ": " + missatges[random].tipus);
                isEnter = true;
                //posarMissatge();
            }
            if (currentTime >= 10f)
            {
               // isEnter = false;
            }
        }

    }


}
