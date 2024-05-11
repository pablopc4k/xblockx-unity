using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerInicio : MonoBehaviour
{
    [SerializeField] GameObject MenuInicio;
    [SerializeField] GameObject FondoMenu;
    [SerializeField] GameObject MenuInicioHelp;
    [SerializeField] GameObject FondoMenuHelp;
    [SerializeField] SoundController sci;

    private bool estaActivado = false;

    void Start()
    {
        sci.Inicio();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            estaActivado = !estaActivado;

            MenuInicioHelp.SetActive(estaActivado);
            FondoMenuHelp.SetActive(estaActivado);
            sci.PausaOn();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
