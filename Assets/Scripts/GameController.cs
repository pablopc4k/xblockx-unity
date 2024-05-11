using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    int sceneId;
    int totalEscenas = 3;
    int nextId;
    [SerializeField] GameObject Pausa;
    [SerializeField] GameObject nivelAcabado;
    [SerializeField] GameObject juegoAcabado;
    [SerializeField] GameObject FondoMenu;
    [SerializeField] SoundController sc;
    [SerializeField] GameObject MetaP1;
    [SerializeField] GameObject MetaP2;
    [SerializeField] Text tiempo;
    [SerializeField] Transform barra;
    [SerializeField] float tiempoTotal; // Tiempo total del temporizador en segundos

    bool puedePasarSiguienteNivel = false;

    private bool estaActivado = false;

    float tiempoRestante;

    void Start()
    {
        sceneId = SceneManager.GetActiveScene().buildIndex;
        nextId = 0;

        Pausa.SetActive(false);

        // Inicializa el tiempo transcurrido a 0
        tiempoRestante = tiempoTotal;
        Time.timeScale = 1f;

        //MetaP1.SetActive(true);
        //MetaP2.SetActive(true);
    }

    void Update()
    {
        // Pausar el juego y mostrar el menú de pausa cuando se presiona la tecla 'P' (por ejemplo)
        if (Input.GetKeyDown(KeyCode.P))
        {
            PausarJuego();
        }

        if (Input.GetKeyDown(KeyCode.Return) && puedePasarSiguienteNivel)
        {
            CargarSiguienteEscena();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            //Time.timeScale = 1f;
            SceneManager.LoadScene(sceneId);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(0);
        }

        // Actualiza el tiempo transcurrido
        tiempoRestante -= Time.deltaTime;      

        if (tiempoRestante <= 0f)
        {
            //sc.JuegoAcaba();
            DetenerJuego();
            tiempoRestante = 0f;
        }

        // Actualiza el Texto del temporizador
        ActualizarTextoTemporizador();
    }

    void DetenerJuego()
    {
        Time.timeScale = 0f;
        //MetaP1.SetActive(false);
        //MetaP2.SetActive(false);
        FondoMenu.SetActive(true);
        juegoAcabado.SetActive(true);
    }

    void PausarJuego()
    {
        estaActivado = !estaActivado;
        if (estaActivado)
        {
            Time.timeScale = 0f;
            FondoMenu.SetActive(true);
            Pausa.SetActive(true);
            sc.PausaOn();
        }
        if (!estaActivado)
        {
            Time.timeScale = 1f;
            FondoMenu.SetActive(false);
            Pausa.SetActive(false);
            sc.PausaOff();
        }
    }

    public void NivelAcabado() {
        Time.timeScale = 0f;
        FondoMenu.SetActive(true);
        nivelAcabado.SetActive(true);
        sc.NivelAcaba();
        puedePasarSiguienteNivel = true;
    }

    void ActualizarTextoTemporizador()
    {
        // Calcula los minutos y segundos
        int minutos = Mathf.FloorToInt(tiempoRestante / 60f);
        int segundos = Mathf.FloorToInt(tiempoRestante % 60f);

        // Actualiza el Texto del temporizador con el formato MM:SS
        tiempo.text = minutos.ToString("00") + ":" + segundos.ToString("00");

        StartCoroutine("BarraTemporizador");
    }

    IEnumerator BarraTemporizador()
    {
        Vector2 barraActual = barra.localScale;
        Vector2 barraFinal = new Vector2(barra.localScale.x, 0f);
        Vector2 barraPosicion = barra.position;
        Vector2 barraPosicionFinal = new Vector2(barra.position.x, -4.46f);
        
        float t = 0;
        while(t < tiempoTotal)
        {
            t += Time.deltaTime;
            barra.localScale = Vector2.Lerp(barraActual, barraFinal, t/tiempoTotal);
            barra.position = Vector2.Lerp(barraPosicion, barraPosicionFinal, t/tiempoTotal);
            yield return null;
        }
    }

    void CargarSiguienteEscena()
    {
        sceneId = SceneManager.GetActiveScene().buildIndex;
        
        if ((sceneId + 1) < totalEscenas) nextId = sceneId + 1;
        SceneManager.LoadScene(nextId);
    }
}
