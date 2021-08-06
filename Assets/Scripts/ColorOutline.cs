using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorOutline : MonoBehaviour
{
    public GameObject textName;
    private Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        outline = this.gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        outline.effectColor = textName.gameObject.GetComponent<Text>().color;
    }
}
