using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLights : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Color> c;
    public Material m;
    public int nColor;
    public int maxColor;
    public float tiempo = 0f;
    public float tiempoMax = 1f;

    void Start()
    {
        nColor = 0;
        maxColor = c.Count;
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= tiempoMax)
        {
            tiempo = 0;

            if(nColor == maxColor-1)
            {
                nColor = 0;
            }
            else
            {
                nColor++;
            }

            //Canviem el color
            m.color = c[nColor];
            m.SetColor("_EmissionColor", c[nColor]);

        }
    }
}
