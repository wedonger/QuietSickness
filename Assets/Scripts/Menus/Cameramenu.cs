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

    void Update()
    {
        if (placaEntrarQuiet)
        {
            transform.position = Vector3.Lerp(transform.position, placaQuietTarget.position, 1 * Time.deltaTime);
            if (transform.position.z >= -3)
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
