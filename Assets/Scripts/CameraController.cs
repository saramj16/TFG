using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float mouseSens = 100f;
    public Transform player;

    float xRotation = 0f;

    public GameObject panelDialeg;
    public GameObject panelResposta;

    public bool desactivat;
    void Start()
    {
        desactivat = false;
        Cursor.visible = true;
    }

    
    void Update()
    {
        if (!panelDialeg.activeSelf && !panelResposta.activeSelf)
        {

            if (desactivat == false)
            {
                Cursor.visible = false;
                float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -90f, 90f);

                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                player.Rotate(Vector3.up * mouseX);
            }
        } else
        {
            Cursor.visible = true;

        }
    
    }


    public void GuardaPosicio(Vector3 pos, Quaternion rot)
    {
        //Debug.Log("Entra aqui");
        this.transform.position = pos;
        this.transform.rotation = rot;
    }
}
