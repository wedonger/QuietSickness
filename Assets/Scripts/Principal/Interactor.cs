using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable 
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;
    private GameObject heldObj;
    public GameObject player;
    private Rigidbody heldObjRb;
    public Transform holdPos;
    private int LayerNumber;
    private bool segurando;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                GameObject obj = hitInfo.collider.gameObject;
                if (obj.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
                switch (obj.tag)
                {
                    case "objPesado":

                        break;
                    case "objMedio":

                        break;
                    case "objLeve":
                        pegarObjeto(hitInfo.collider.gameObject, 0);
                        break;
                }
            }
        }
    }
    void pegarObjeto(GameObject objetor, int qualPeso)
    {
        if (segurando)
        {
            soltaObjeto();
            segurando = false;
            return;
        }
        if (objetor.GetComponent<Rigidbody>()) //make sure the object has a RigidBody
        {
            heldObj = objetor; //assign heldObj to the object that was hit by the raycast (no longer == null)
            heldObjRb = objetor.GetComponent<Rigidbody>(); //assign Rigidbody
            heldObjRb.isKinematic = true;
            heldObjRb.transform.parent = holdPos.transform; //parent object to holdposition
            heldObj.layer = LayerNumber; //change the object layer to the holdLayer
            Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), true);
        };
        segurando = true;
    }
    void soltaObjeto()
    {
        Physics.IgnoreCollision(heldObj.GetComponent<Collider>(), player.GetComponent<Collider>(), false);
        heldObj.layer = 0; //object assigned back to default layer
        heldObjRb.isKinematic = false;
        heldObj.transform.parent = null; //unparent object
        heldObj = null; //undefine game object
    }
}
