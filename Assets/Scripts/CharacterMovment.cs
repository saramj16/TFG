using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovment : MonoBehaviour
{
    public CharacterController controller;

    float speed = 0f;
    float speedNormal = 5f;
    float speedFast = 30f;
    float gravity = -9.81f;

    public bool blockMovment = true;

    Vector3 velocity;

    public GameObject panelDialeg;
    public GameObject panelResposta;
    private void Start()
    {
        speed = speedNormal;
        blockMovment = true;
    }

    void Update()
    {
        
        if (!panelDialeg.activeSelf && !panelResposta.activeSelf)
        {

            if (blockMovment == true)
            {
                float x = Input.GetAxis("Horizontal");
                float z = Input.GetAxis("Vertical");

                Vector3 movement = transform.right * x + transform.forward * z;

                controller.Move(movement * speed * Time.deltaTime);

                velocity.y += gravity * Time.deltaTime;

                controller.Move(velocity * Time.deltaTime);

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    //Debug.Log("Fast");
                    speed = speedFast;
                }
                if (Input.GetKeyUp(KeyCode.LeftShift))
                {
                   // Debug.Log("Lento");
                    speed = speedNormal;
                }
            }
        } 
        
    }

    public void AcabesMalament()
    {
        Debug.Log("Pos rip pq tha violat");
    }
}
