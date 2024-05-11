using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    AudioSource sfx;
    [SerializeField] AudioClip sfxInicio;
    [SerializeField] AudioClip sfxJuegoEmpieza;
    [SerializeField] AudioClip sfxJuegoAcaba;
    [SerializeField] AudioClip sfxNivelAcaba;
    [SerializeField] AudioClip sfxMuro;
    [SerializeField] AudioClip sfxInterruptorOn;
    [SerializeField] AudioClip sfxInterruptorOff;
    [SerializeField] AudioClip sfxPausaOn;
    [SerializeField] AudioClip sfxPausaOff;

    // Start is called before the first frame update
    void Start()
    {
        sfx = GetComponent<AudioSource>();
        JuegoEmpieza();
    }

    public void Inicio(){
        sfx.clip = sfxInicio;
        sfx.Play();
    }

    public void JuegoEmpieza(){
        sfx.clip = sfxJuegoEmpieza;
        sfx.Play();
    }

    public void JuegoAcaba(){
        sfx.clip = sfxJuegoAcaba;
        sfx.Play();
    }

    public void NivelAcaba(){
        sfx.clip = sfxNivelAcaba;
        sfx.Play();
    }

    public void Muro(){
        sfx.clip = sfxMuro;
        sfx.Play();
    }

    public void InterruptorOn(){
        sfx.clip = sfxInterruptorOn;
        sfx.Play();
    }

    public void InterruptorOff(){
        sfx.clip = sfxInterruptorOff;
        sfx.Play();
    }

    public void PausaOn(){
        sfx.clip = sfxPausaOn;
        sfx.Play();
    }

    public void PausaOff(){
        sfx.clip = sfxPausaOff;
        sfx.Play();
    }
}
