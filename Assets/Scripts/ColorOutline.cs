using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorOutline : MonoBehaviour
{
    public GameObject textName;
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.color = textName.gameObject.GetComponent<Text>().color;
    }
}
