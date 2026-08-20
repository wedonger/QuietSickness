using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class saveSystem
{
    public static galoClasse buscaJson() 
    {
        verificaJsonExiste();
        string caminho = Application.persistentDataPath + "/galo.json";
        string jsonStr = File.ReadAllText(caminho);
        galoClasse obj = JsonUtility.FromJson<galoClasse>(jsonStr); 
        return obj;
    }
    public static void salvaJson(galoClasse galo)
    {
        verificaJsonExiste();
        Debug.Log("galo");
        string caminho = Application.persistentDataPath + "/galo.json";
        FileStream stream = new FileStream(caminho, FileMode.Create);
        var json = JsonUtility.ToJson(galo);
        File.WriteAllText(caminho, json);
    }
    public static async void verificaJsonExiste() 
    {
        string caminho = Application.persistentDataPath + "/galo.json";
        if (!File.Exists(caminho))
        {
            string jsonner = JsonUtility.ToJson(new galoClasse());
            File.WriteAllText(caminho, jsonner);
            Debug.LogError("Não encontramos nada nesse caminho: " + caminho + ", foi criado um arquivo novo com os dados zerados");
        }
        string json = File.ReadAllText(caminho);
        galoClasse obj = new galoClasse();
        obj = JsonUtility.FromJson<galoClasse>(json);
    }
    public static void salvaDias(CounterTempo obj) 
    {
        salvaDias data = new salvaDias(obj);
        galoClasse json = new galoClasse();
        json.salvaDias = data;
        salvaJson(json);
    }
    public static salvaDias loadDias()
    {
        galoClasse data = buscaJson();
        salvaDias obj = data.salvaDias;
        if (obj == null) {
            obj = new salvaDias(new CounterTempo());
            obj.min = 0;    
            obj.dia = 0;
            obj.hora = 0;
        }
        return obj;
    }
    public static void salvaPosBarco(Barco obj) 
    {
        string caminho = Application.persistentDataPath + "/galo.json";
        FileStream stream = new FileStream(caminho, FileMode.Create);
        galoClasse jsonbrabo = new galoClasse();
        Barco data = new Barco();
        if (obj == null)
        {
            data = obj;
        }
        jsonbrabo.Barco = data;
        var json = JsonUtility.ToJson(jsonbrabo);

        stream.Close();
    }
    public static Barco loadPosBarco()
    {
        galoClasse jsonbrabo = buscaJson();
        Barco obj = jsonbrabo.Barco;
        return obj;
    }
    public static void salvaPosPlayer(cactomove player)
    {
        string caminho = Application.persistentDataPath + "/galo.json";
        FileStream stream = new FileStream(caminho, FileMode.Create); 
        salvaPlayer data = new salvaPlayer(player);
        galoClasse jsonbrabo = new galoClasse();

        jsonbrabo.salvaPlayer = data;
        var json = JsonUtility.ToJson(jsonbrabo);

        File.WriteAllText(caminho, json);

        stream.Close();
    }
    public static void loadPosPlayer()
    {
        var json = buscaJson();
        salvaPlayer obj = json.salvaPlayer;
        if (obj is not null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.localPosition = new Vector3(obj.x, obj.y, obj.z);
        }
    }
}
