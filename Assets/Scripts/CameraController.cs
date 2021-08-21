using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    float sensibilitatMouse = 140f;
    public Transform player;

    float xRotation = 0f;
    float yRotation = 0f;

    public GameObject cameraSecundaria;

    public float clamp;

    public bool desactivat;
    void Start()
    {
        clamp = 90;
        desactivat = false;
        Cursor.visible = true;
    }

    
    void Update() {
        if (!cameraSecundaria.GetComponent<CameraSecundaria>().conversaEnCurs) {
            Cursor.visible = false;
            if (desactivat == false) {
                this.gameObject.GetComponent<Camera>().enabled = true;

                float mouseX = Input.GetAxis("Mouse X") * sensibilitatMouse * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * sensibilitatMouse * Time.deltaTime;

                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -clamp, clamp);

                yRotation -= mouseX;
                yRotation = Mathf.Clamp(yRotation, -clamp, clamp);

                transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
                player.Rotate(Vector3.up * mouseX);
            }
        } else {
            Cursor.visible = true;
        }
    }

    public void OnHaDeMirar(GameObject cam)
    {
        //Debug.Log("Entra aqui");
        this.gameObject.transform.position = cam.transform.position;
        this.gameObject.transform.rotation = cam.transform.rotation;
    }
}
