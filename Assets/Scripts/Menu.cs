using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject panellMenu;
    public GameObject panellLoading;
    public GameObject panellCredits;
 

    public void OnClickPlay()
    {
        SceneManager.LoadScene("Mapa_UIambMA");
        panellMenu.SetActive(false);
        panellLoading.SetActive(true);
        CanviaEstatCanvas();
    }

    public void OnClickCredits()
    {
        panellMenu.SetActive(false);
        panellCredits.SetActive(true);
        StartCoroutine(Credits());
        CanviaEstatCanvas();
        //Debug.Log("Ha Clickat CREDITS");
    }

    public void OnClickExit()
    {
        Application.Quit();
    }

    private IEnumerator Credits()
    {
        GameObject panel = panellCredits.gameObject.transform.GetChild(0).gameObject;
        float y = panel.transform.position.y;
        while (panel.transform.position.y < 30f)
        {
            yield return new WaitForSeconds(0.01f);
            y = y + 0.05f;
            panellCredits.gameObject.transform.GetChild(0).gameObject.transform.position = new Vector3(panel.transform.position.x, y, panel.transform.position.z);
        }

        panellCredits.SetActive(false);
        CanviaEstatCanvas();
        panellMenu.SetActive(true);

        panellCredits.gameObject.transform.GetChild(0).gameObject.transform.position = new Vector3(panel.transform.position.x, -15.5f, panel.transform.position.z);
    }

    private void CanviaEstatCanvas()
    {
        for(int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            this.gameObject.transform.GetChild(i).gameObject.SetActive(!this.gameObject.transform.GetChild(i).gameObject.activeSelf);
        }

    }
}
