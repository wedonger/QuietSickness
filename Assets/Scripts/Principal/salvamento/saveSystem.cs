using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using UnityEngine;

public static class saveSystem
{
    public static void salvaDias(CounterTempo obj) 
    {
        string caminho = Application.persistentDataPath + "/galo.json";
        FileStream stream = new FileStream(caminho, FileMode.Create);
        salvaDias data = new salvaDias(obj);
        var json = JsonUtility.ToJson(data);
        
        stream.Close();
    }
    public static salvaDias loadDias()
    {
        string caminho = Application.persistentDataPath + "/galo.json";
        if (File.Exists(caminho))
        {
            salvaDias obj = JsonUtility.FromJson<salvaDias>(caminho);
            return obj;
        }
        else
        {
            Debug.LogError("Não encontramos nada nesse caminho: " + caminho + ", nele ficava o save, verifique se foi alterado as pastas do jogo, ou formatado o pc");
            return null;
        }
    }
    public static void salvaPosBarco(Barco obj) 
    {
        string caminho = Application.persistentDataPath + "/galo.json";
        FileStream stream = new FileStream(caminho, FileMode.Create);
        Barco data = new Barco();
        var json = JsonUtility.ToJson(data);

        stream.Close();
    }
    public static salvaDias loadPosBarco()
    {
        string caminho = Application.persistentDataPath + "/galo.json";
        if (File.Exists(caminho)) 
        {
            salvaDias obj = JsonUtility.FromJson<salvaDias>(caminho);
            return obj;
        }
        else 
        {
            Debug.LogError("Não encontramos nada nesse caminho: " + caminho + ", nele ficava o save, verifique se foi alterado as pastas do jogo, ou formatado o pc");
            return null;
        }
    }
}
