using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorBloque : MonoBehaviour
{
    [SerializeField] float speed = 7f;

    [SerializeField] GameObject clon;

    [SerializeField] GameManager gm;

    [SerializeField] SoundController sc;


    //Diferencia de distacia del clon con el personaje principal

    float clonX = 9f;
    Vector2 posicionClon;

    bool switch1 = false;
    bool switch2 = true;
    bool switch3 = true;

    void IniciarMuros()
    {
        if (switch1) AlternarMuros("Muro1", true);
        if (switch2) AlternarMuros("Muro2", true);
        if (switch3) AlternarMuros("Muro3", true);
    }

    void DesactivarTodosLosMuros()
    {
        string[] muros = { "Muro1", "Muro2", "Muro3" };

        foreach (string muro in muros)
        {
            AlternarMuros(muro, false);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        string tag = other.gameObject.tag;
         if (tag == "Muro" || tag == "Muro1" || tag == "Muro2" || tag == "Muro3") sc.Muro();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.tag == "sw1") || (other.tag == "sw2"))
        {
            switch1 = ActivarInterruptor("Muro1", switch1);
            switch2 = ActivarInterruptor("Muro2", switch2);
        }
        if (other.tag == "sw3") switch3 = ActivarInterruptor("Muro3", switch3);
        if (other.tag == "Meta") {
            //gm.DetenerJuego();
            gm.NivelAcabado();
        }
    }

    bool ActivarInterruptor(string obj, bool sw)
    {
        if (!sw)
        {
            AlternarMuros(obj, true);
            sw = true;
            sc.InterruptorOff();
        }else{
            AlternarMuros(obj, false);
            sw = false;
            sc.InterruptorOn();
        }

        return sw;
    }

    void AlternarMuros(string obj, bool activar)
    {
        GameObject[] objetos = Resources.FindObjectsOfTypeAll<GameObject>();

        foreach (GameObject objeto in objetos)
        {
            if (objeto.tag == obj)
            {   
                if (activar) objeto.SetActive(true);
                else objeto.SetActive(false);
            }
        }
    }

    void Start()
    {
        Cursor.visible = false;
        DesactivarTodosLosMuros();
        IniciarMuros();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left")) {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
            transform.localScale = new Vector2(-4.5f, transform.localScale.y);
        }

        if (Input.GetKey("right")) {
            transform.Translate(speed * Time.deltaTime * Vector3.right);
            transform.localScale = new Vector2(4.5f, transform.localScale.y);
        }

        if (Input.GetKey("up")) {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
        }

        if (Input.GetKey("down")) {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
        }
        clon.transform.position = new Vector2(transform.position.x + clonX, transform.position.y);
        clon.transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y);
    }
}
