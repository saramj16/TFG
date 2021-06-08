using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterPositions : MonoBehaviour
{

    public GameObject personatge;
    float y;

    // Start is called before the first frame update
    void Start()
    {
        y = this.transform.position.y;
        this.transform.position = personatge.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 aux = personatge.transform.position;
        aux.y = y;
        this.transform.position = aux;
        
        
    }
}
