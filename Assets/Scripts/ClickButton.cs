using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{
    Button b;
    public bool hanClickat = false;
    public FollowGirl fg;
    void Start()
    {
        hanClickat = false;
        b = this.gameObject.GetComponent<Button>();
        b.onClick.AddListener(TaskOnClick);
    }


    void TaskOnClick()
    {
        hanClickat = true;
        fg.AnswerString(b.name);
        Debug.Log(b.name);
    }
}
