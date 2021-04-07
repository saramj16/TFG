using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float sensibilitatMouse = 140f;
    public Transform player;

    float xRotation = 0f;
    float yRotation = 0f;

    public GameObject panelDialeg;
    public GameObject panelResposta;

    public float clamp;

    public bool desactivat;
    void Start()
    {
        clamp = 90;
        desactivat = false;
        Cursor.visible = true;
    }

    
    void Update()
    {
        if (!panelDialeg.activeSelf && !panelResposta.activeSelf)
        {
            Cursor.visible = false;
            float mouseX = Input.GetAxis("Mouse X") * sensibilitatMouse * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensibilitatMouse * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -clamp, clamp);

            yRotation -= mouseX;
            yRotation = Mathf.Clamp(yRotation, -clamp, clamp);

            if (desactivat == false)
            {
                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                player.Rotate(Vector3.up * mouseX);
            } else
            {
                transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
            }
        } else
        {
            Cursor.visible = true;

        }
    
    }

    public void ChangeClamp(float value, float min, float max)
    {
        xRotation = Mathf.Clamp(value, min, max);
    }
    public void GuardaPosicio(Vector3 pos, Quaternion rot)
    {
        //Debug.Log("Entra aqui");
        this.transform.position = pos;
        this.transform.rotation = rot;
    }
}
