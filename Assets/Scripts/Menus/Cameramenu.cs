using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cameramenu : MonoBehaviour
{
    public bool placaEntrarQuiet;
    public bool placaConfig;
    public Transform placaQuietTarget;
    public Animator animatorConfig;
    public Transform camera;

    void Update()
    {
        if (placaEntrarQuiet)
        {
            animatorConfig.SetBool("entrarGame", true);
            if (camera.position.z >= -3)
            { 
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }
        }
        if (placaConfig)
        {
            animatorConfig.SetBool("LigoAgrDelisga", true);
        }
    }
}
