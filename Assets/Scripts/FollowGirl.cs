using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FollowGirl : MonoBehaviour
{
    private bool haArribat;
    public GameObject target;
    public float speed = 20f;

    bool activaRespostes;

    int option = 1;

    public GameObject panelRespostes;
    public GameObject panelMissatges;

    public List<Dialeg> dialegNoi;
    public List<Respostes> respostes;

    public VisualMissatge vm;

    private int answer;
    void Start()
    {
        answer = 0;
        option = 1;
        activaRespostes = false;
        haArribat = false;
    }


    void Update()
    {
        
        // Primer ens diu hola guapa l'altre script, i quan marxem ens han de sortir les opcions de resposta
        switch (option)
        {
            case 1:
                PassaPelCostat();
                break;
            case 2:
                MarxaDelGrup();
                //RespondreNoia();
                break;
            case 3:
               // answer = RespondreNoia(1);
                break;
            case 4:
             /*   Debug.Log("Answer" + answer);
                if (answer == 4)
                {
                    NoiParlant(dialegNoi[0].tipus);
                    Invoke("NoiParlant" + dialegNoi[1].tipus, 3f);
                    Invoke("CanviaOpcio", 5f);
                    
                }
                CanviaOpcio();*/
                break;
            case 5:
               /* Invoke("NoiParlant" + dialegNoi[2].tipus, 3f);
                Invoke("NoiParlant" + dialegNoi[3].tipus, 4f);
                Invoke("Respondre noia" + 1, 6f);*/
                break;

        }
        

    }

    public void AnswerString(string s)
    {
        Debug.Log("Entra a Answer String");
        if (s.Equals("Resposta 1"))
        {
            answer = 1;
        }        
        if (s.Equals("Resposta 2"))
        {
            answer = 2;
        }        
        if (s.Equals("Resposta 3"))
        {
            answer = 3;
        }        
        if (s.Equals("Resposta 4"))
        {
            answer = 4;
        }
    }

    void NoiParlant(string s)
    {
        if (!panelMissatges.activeSelf)
        {
            panelMissatges.SetActive(true);
        }
        Debug.Log("Noi parlant.");
        vm.CreaMissatge(s);
    }

    void PassaPelCostat()
    {

        //Debug.Log("Opcio 1  ->  Passa pel costat");
        float dist = Vector3.Distance(target.gameObject.transform.position, transform.position);
        if (dist < 20f)
        {
            haArribat = true;
            CanviaOpcio();
        }
    }

    void MarxaDelGrup()
    {
        //Debug.Log("Opcio 2  ->  Marxa del grup");
        float dist = Vector3.Distance(target.gameObject.transform.position, transform.position);
        if (haArribat && dist > 20f)
        {
            haArribat = false;

            Conversa();
           // vm.CreaMissatge(this.gameObject.name + ": " + dialegNoi[0].tipus);

            //Invoke("CanviaOpcio", 5f);
    
            
            //Debug.Log("Seguir a la noia");
            //Follow girl hem de fer que si la mires pari de moures

        }
    }


    private float lastTime = -1;
    void Conversa()
    {
        Debug.Log("Anem a parlar");
        int contador = 0;
        int torn = 0;
        int tornFinal = dialegNoi[dialegNoi.Count-1].torn;

        float inici = 0;
        float timer = 3f;


        while (torn <= 100)
        {

            float delta = 0;
            if (lastTime > 0)
            {
                delta = Time.time - lastTime;
                Debug.Log("Delta between last call = " + delta);
                torn++;
            }
            lastTime = Time.time;
        }
          /*  if (!panelRespostes.activeSelf)
            {
                vm.CreaMissatge(this.gameObject.name + ": " + dialegNoi[contador].missatge);


                if (dialegNoi[contador + 1].torn != torn)
                {
                    // Posar resposta noia i esperar la resposta
                    
                    Debug.Log("Entra al dialeg");


                    panelRespostes.SetActive(true);

                   // Debug.Log("Respostes: " + respostes[torn].resposta1);
                    //
                    panelMissatges.SetActive(false);
                    
                   // panelRespostes.gameObject.GetComponent<ChooseAnswer>().OmplirOpcions(respostes[0]);
          

                   // Debug.Log("Activar respostes " + panelRespostes.activeSelf);

                    // torn++;
                    Debug.Log("Torn " + torn);
                    torn++;
                }

                timer -= Time.deltaTime;

                if(timer <= inici)
                {
                    Debug.Log("Contador " + contador);
                    contador++;
                    timer = 3f;
                }

            }
        }
       */
    }
    int RespondreNoia(int option)
    {
        //Debug.Log("Opcio 3  ->  Respondre al imbecil");
        if (!activaRespostes)
        {
            string[] texts = new string[4];
            if (option == 1)
            {
                texts[0] = respostes[0].resposta1;
                texts[1] = respostes[0].resposta2;
                texts[2] = respostes[0].resposta3;
                texts[3] = respostes[0].resposta4;
            }            
            if (option == 2)
            {
                texts[0] = respostes[1].resposta1;
                texts[1] = respostes[1].resposta2;
                texts[2] = respostes[1].resposta3;
                texts[3] = respostes[1].resposta4;
            }



         /*   panelRespostes.gameObject.GetComponent<EscollirResposta>().OmplirOpcions(texts);
            panelRespostes.SetActive(true);
            activaRespostes = true;*/
        }

        if (!panelRespostes.activeSelf)
        {
            //Debug.Log("Entra aqui noia respon");
            CanviaOpcio();
            return answer;
        }
        return answer;
    }

    void SeguintNoia()
    {
        //Debug.Log("Opcio 4  ->  Seguint a la guarra aquesta");
        
        float dot = Vector3.Dot(target.transform.forward, (this.transform.position - target.transform.position).normalized);
        if (dot < 0.7f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        }
    }


    void CanviaOpcio()
    {
        option++;
    }
}
