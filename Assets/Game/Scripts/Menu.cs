using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Start()
    {
        CambiarIdiomaTextos();
    }

    public void SelectLanguage(string language)
    {
        MyResources.Singleton.Language = language;
        CambiarIdiomaTextos();
    }

    void CambiarIdiomaTextos()
    {
        string baseTexto = "Canvas/";
        GameObject.Find(baseTexto + "NuevaPartida/Text").GetComponent<TextMeshProUGUI>().text = TextManager.GetText("NuevaPartida");
        GameObject.Find(baseTexto + "LeerPartida/Text").GetComponent<TextMeshProUGUI>().text = TextManager.GetText("LeerPartida");
        GameObject.Find(baseTexto + "Salir/Text").GetComponent<TextMeshProUGUI>().text = TextManager.GetText("Salir");

        GameObject.Find(baseTexto + "Botones/Ingles/Text").GetComponent<TextMeshProUGUI>().text = TextManager.GetText("Ingles");
        GameObject.Find(baseTexto + "Botones/Espanol/Text").GetComponent<TextMeshProUGUI>().text = TextManager.GetText("Espanol");


    }
    public void NuevaPartidaClick()
    {
        SceneManager.LoadScene("Main");
        PlayerPrefs.SetInt("NuevaPartida", 1);
    }

    public void CargarPartidaClick()
    {
        SceneManager.LoadScene("Main");
        PlayerPrefs.SetInt("NuevaPartida", 0);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }


    
    void Update()
    {
        
    }
}




