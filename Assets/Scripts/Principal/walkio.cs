using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class walkio : MonoBehaviour
{
    public TMP_Text texto;
    public int volume = 0;
    private float frequencia = 100;
    private float Maxfrequencia = 100;
    public float senseTrocarFreq = 10;
    private float volumeGeralDasTransimssao = 1f;
    public AudioSource chiadoGlobal;
    public Transform player;
    void Update()
    {
        string cardinal = buscaCardinal();
        atualizaCoordenadas(cardinal);
        modulaFrequencia();
        chiadoGlobal.volume = atualizaVolumeGeral() * volume / 100;
    }
    void atualizaCoordenadas(string cardinais) {
        texto.text = @$"X: {transform.position.x} Z: {transform.position.z}
                freq: {frequencia}Hz
                compass: {cardinais}";
    }
    float BuscaMultiplierChiado(Transform emissor) 
    {
        Vector3 toTarget = (emissor.position - transform.position).normalized;
        float dot = Vector3.Dot(transform.forward, toTarget);
        return dot < 0 ? dot * -1 : dot;
    }
    public float atualizaVolumeGeral() 
    {
        float oqSobrouDeVolume = volumeGeralDasTransimssao;
        GameObject[] emissores = GameObject.FindGameObjectsWithTag("emissorDeRadio");
        for (int i = 0; i < emissores.Length; i++)
        {
            float geralMenosMultiplier = (volumeGeralDasTransimssao - BuscaMultiplierChiado(emissores[i].transform));
            geralMenosMultiplier = calculaDiffFrequencia(emissores[i], geralMenosMultiplier);
            emissores[i].GetComponent<AudioSource>().volume = geralMenosMultiplier * volume / 100;
            oqSobrouDeVolume -= geralMenosMultiplier;
        }
        return oqSobrouDeVolume;
    }
    public float calculaDiffFrequencia(GameObject emissor, float valorMultiplier) 
    {
        Match match = Regex.Match(emissor.name, @"\(([^)]*)\)");
        int freqEmissor = Convert.ToInt32(match.Groups[1].Value);
        float vidr = frequencia - freqEmissor;
        if (vidr < 0) {
            vidr = vidr * -1;
        }
        if (vidr >= 20 || vidr <= -20)
        {
            valorMultiplier = 0;
        }
        else {
            valorMultiplier -= vidr / 100;
        }
        return valorMultiplier;
    }
    public void modulaFrequencia() 
    {
        float coeficienteFreq = Input.GetAxis("Mouse ScrollWheel") * senseTrocarFreq;
        if (frequencia + coeficienteFreq < Maxfrequencia && frequencia + coeficienteFreq > 0) {
            frequencia += coeficienteFreq;
        }
    }
    public string buscaCardinal()
    {
        Vector3 direcao2D = new Vector3(transform.forward.x, 0f, transform.forward.z).normalized;

        float angulo = Vector3.SignedAngle(Vector3.forward, direcao2D, Vector3.up);
        float anguloCerto = (angulo + 360f) % 360f;
        if (angulo >= -45f && angulo < 45f)
            return "Norte " + anguloCerto; 
        else if (angulo >= 45f && angulo < 135f)
            return "Leste " + anguloCerto; 
        else if (angulo >= -135f && angulo < -45f)
            return "Oeste " + anguloCerto;
        else
            return "Sul " + anguloCerto;
    }
}
