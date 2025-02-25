using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class gameOptions : MonoBehaviour
{
    public static float volumeAmbience = 1f;
    public static float volumeMusica = 1f;
    public static float volumeBicho = 1f;

    public static float brightness = 1f;

    public static float sense = 1f;

    public Slider slide;
    public PostProcessProfile brilho;
    public PostProcessLayer viros;
    AutoExposure exposure;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void Start()
    {
        brilho.TryGetSettings(out exposure);
        AjustaBrilho(slide.value);
    }

    public void AjustaBrilho(float valor)
    {
        if (valor != 0)
        {
            exposure.keyValue.value = valor;
        }
        else {
            exposure.keyValue.value = .01f;
        }
    }

    public static void Load()
    {
        volumeAmbience = PlayerPrefs.GetFloat("Volume", 1f);
        PlayerPrefs.GetFloat("Brightness", 1f);
    }

    public static void salvaVolumeAmbience()
    {
        PlayerPrefs.SetFloat("Volume", volumeAmbience);
    }


}
