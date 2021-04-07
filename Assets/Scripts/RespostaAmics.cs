using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespostaAmics : MonoBehaviour
{
    public GameObject target;
      
    public bool isEnter = false;
    bool haArribat = false;
    bool enPosicio = false;

    int option;

    public GameObject waypoints;

    private Animator animatorAmic1;
    private Animator animatorAmic2;

    private GameObject amic1;
    private GameObject amic2;

    private bool posicionats = false;

    float speed = 7f;

    public GameObject childCamera;
    // Start is called before the first frame update
    void Start()
    {
        isEnter = false;
        haArribat = false;
        enPosicio = false;
        option = 0;

        amic1 = this.gameObject.transform.GetChild(0).gameObject;
        amic2 = this.gameObject.transform.GetChild(1).gameObject;

        animatorAmic1 = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
        animatorAmic2 = this.gameObject.transform.GetChild(1).gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (option)
        {
            case 0:
                ArribaAmics();
                break;
            case 1:
                PosicionarPersonatge();
                break;
            case 2:
                Debug.Log("Cas 2: Anem cap a waypoint");
                GoToWaypoint();
                break;
            case 3:
                //Debug.Log("Cas 3: Els amics marxen");
                Marxen();
                break;
            case 4:
                break;

        }
    }

    void MourePersonatges(Vector3 p1, Vector3 p2)
    {
        //Posicionar els amics tmb

       // Debug.Log("Rotar amics personatge");
        Quaternion rotationAmic1;
         do
          {
           rotationAmic1 = Quaternion.LookRotation(p1 - amic1.transform.position);
           amic1.transform.rotation = Quaternion.RotateTowards(amic1.transform.rotation, rotationAmic1, Time.deltaTime * 70f);

           Quaternion rotationAmic2 = Quaternion.LookRotation(p2 - amic2.transform.position);
           amic2.transform.rotation = Quaternion.RotateTowards(amic2.transform.rotation, rotationAmic2, Time.deltaTime * 70f);
          } while (amic1.transform.rotation != rotationAmic1);

        posicionats = true;

    }
    private void PosicionarPersonatge()
    {
        if (enPosicio == false)
        {
           // Debug.Log("Waypoint: " + waypoints.gameObject.transform.GetChild(0).name);
            target.transform.position = Vector3.MoveTowards(target.transform.position, waypoints.gameObject.transform.GetChild(0).position, (speed / 2) * Time.deltaTime);

            Vector3 puntMig = amic2.transform.position - amic1.transform.position;
            puntMig.x = amic1.transform.position.x + (puntMig.x / 2);
            puntMig.y = 2.85f;
            puntMig.z = amic1.transform.position.z + puntMig.z / 2;

            Quaternion targetRotation = Quaternion.LookRotation(puntMig - childCamera.transform.position);
            childCamera.gameObject.transform.rotation = Quaternion.RotateTowards(childCamera.gameObject.transform.rotation, targetRotation, Time.deltaTime * 4f);

            //Posicionar els amics tmb
            MourePersonatges(waypoints.gameObject.transform.GetChild(1).position, waypoints.gameObject.transform.GetChild(2).position);

            //Debug.Log("Seguim i es mouen");
            float dist = Vector3.Distance(target.gameObject.transform.position, waypoints.gameObject.transform.GetChild(0).position);
            if (dist < 10f && posicionats)
            {
                enPosicio = true;
                //Debug.Log("Anem a la seguent opció");
                Invoke("CanviaOption", 1f);
            }
        }
    }
    public void ArribaAmics()
    {
        float dist = Vector3.Distance(target.gameObject.transform.position, this.transform.position);

        if (dist < 20f)
        {
            if (isEnter == false)
            {
                isEnter = true;

                target.gameObject.GetComponent<CharacterMovment>().blockMovment = false;

                childCamera.gameObject.GetComponent<CameraController>().desactivat = true;

                Invoke("CanviaOption", 1f);

            }
        }

    }
    public void GoToWaypoint()
    {

        //Debug.Log("Go to Waypoint");

        if(haArribat == false)
        {
            target.gameObject.GetComponent<Flowchart>().SetBooleanVariable("Conversa", true);

            animatorAmic1.SetBool("isWalking", true);
            animatorAmic2.SetBool("isWalking", true);
            

            target.transform.position = Vector3.MoveTowards(target.transform.position, waypoints.gameObject.transform.GetChild(3).position, speed * Time.deltaTime);

            //Hem de mirar la distancia de cadascun per fer que ja no es moguin
            float dist_amic1 = Mathf.Abs(Vector3.Distance(amic1.transform.position, waypoints.gameObject.transform.GetChild(1).position));
            if (dist_amic1 > 5f)
            {                
                this.gameObject.transform.GetChild(0).transform.position = Vector3.MoveTowards(amic1.transform.position, waypoints.gameObject.transform.GetChild(1).position, speed * Time.deltaTime);

            } else {
                animatorAmic1.SetBool("isWalking", false);
                //Debug.Log("L'amic 1 se frena el maquina");
            }

            float dist_amic2 = Mathf.Abs(Vector3.Distance(amic2.transform.position, waypoints.gameObject.transform.GetChild(2).position));
            if (dist_amic2 > 5f)
            {
                this.gameObject.transform.GetChild(1).transform.position = Vector3.MoveTowards(amic2.transform.position, waypoints.gameObject.transform.GetChild(2).position, speed * Time.deltaTime);
            }
            else {
                animatorAmic2.SetBool("isWalking", false);
                // Debug.Log("L'amic 2 ja ha parat");
            }

            float dist = Mathf.Abs(Vector3.Distance(target.gameObject.transform.position, waypoints.gameObject.transform.GetChild(3).position));

            // Buscar punt mig entre els dos amics
            Vector3 puntMig = amic2.transform.position - amic1.transform.position;
            puntMig.x = amic1.transform.position.x + (puntMig.x/2);
            puntMig.y = 2.85f;
            puntMig.z = amic1.transform.position.z + puntMig.z/2;

            Quaternion targetRotation = Quaternion.LookRotation(puntMig - childCamera.transform.position);
            childCamera.gameObject.transform.rotation = Quaternion.RotateTowards(childCamera.gameObject.transform.rotation, targetRotation, Time.deltaTime * 3f);

            if (dist < 1f){

                haArribat = true;

                MourePersonatges(waypoints.gameObject.transform.GetChild(4).position, waypoints.gameObject.transform.GetChild(5).position);
                Invoke("CanviaOption", 4f);
            }
        }  
        
    }

    public void Marxen()
    {
                
        float dist = Mathf.Abs(Vector3.Distance(amic1.transform.position, waypoints.gameObject.transform.GetChild(4).transform.position));
        if (dist < 30f)
        {
            target.gameObject.GetComponent<CharacterMovment>().blockMovment = true;

            childCamera.gameObject.GetComponent<CameraController>().desactivat = false;
            //childCamera.gameObject.GetComponent<CameraController>().GuardaPosicio(childCamera.transform.position, childCamera.transform.rotation);
            option = 3;


            animatorAmic1.SetBool("isWalking", false);
            animatorAmic2.SetBool("isWalking", false);
            Destroy(this);
            // Debug.Log("Ja pots marxar");
            //vm.CreaMissatge("Hora d'anar a casa.");

        } else
        {
            //Debug.Log("Es mouen cap al seu lloc");
            animatorAmic1.SetBool("isWalking", true);
            animatorAmic2.SetBool("isWalking", true);
            amic1.transform.position = Vector3.MoveTowards(amic1.transform.position, waypoints.gameObject.transform.GetChild(4).position, speed * Time.deltaTime);
            amic2.transform.position = Vector3.MoveTowards(amic2.transform.position, waypoints.gameObject.transform.GetChild(5).position, speed * Time.deltaTime);

            Vector3 puntMig = amic2.transform.position - amic1.transform.position;
            puntMig.x = amic1.transform.position.x + (puntMig.x / 2);
            puntMig.y = 2.85f;
            puntMig.z = amic1.transform.position.z + puntMig.z / 2;
            
            Quaternion targetRotation = Quaternion.LookRotation(puntMig - childCamera.transform.position);
            childCamera.gameObject.transform.rotation = Quaternion.RotateTowards(childCamera.gameObject.transform.rotation, targetRotation, Time.deltaTime * 3f);

        }

    }

    void CanviaOption()
    {
        option++;
    }
}
