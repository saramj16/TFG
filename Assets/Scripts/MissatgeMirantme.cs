using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissatgeMirantme : MonoBehaviour
{
    public List<Missatge> missatges;
    public VisualMissatge vm;
    public bool isEnter = false;

    public void posarMissatge()
    {
        if (!isEnter)
        {
            int random = Random.Range(0, missatges.Count);
            vm.CreaMissatge(this.name + ": " + missatges[random].tipus);
            isEnter = true;
            Invoke("posarEnterFalse", 10.0f);
        }

    }

    public void posarEnterFalse()
    {
        isEnter = false;
    }
}
