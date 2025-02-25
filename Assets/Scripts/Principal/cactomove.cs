using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cactomove : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 40;
    public GameObject mover;
    public float movx;
    public float movy;
    public bool isGrounded;
    public float jumpForce = 2;
    private Rigidbody rb;
    public LayerMask chao;
    public bool atacando;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        trapa:
        turn.x += Input.GetAxis("Mouse X") * sensitivity;

        if (EnterBarco.instance.inVehicle)
        {
            if (turn.x >= 180)
            {
                turn.x = 180;
            }
            else if (turn.x <= -180)
            {
                turn.x = -180;
            }
            goto trapa;
        }

        if (turn.x >= 360)
        {
            turn.x = 0;
        }
        else if (turn.x <= -360)
        {
            turn.x = 0;
        }
        transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        mover.transform.localRotation = Quaternion.Euler(0, turn.x, 0);

        movx = Input.GetAxisRaw("Horizontal") * speed;
        movy = Input.GetAxisRaw("Vertical") * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movx = movx * 2;
            movy = movy * 2;
        }

        deltaMove = new Vector3(movx, 0, movy) * Time.deltaTime * 2;
        mover.transform.Translate(deltaMove);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.5f);

        if (!isGrounded)
        {
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        else 
        {
            turn.y = 0;
        }

        if (isGrounded && Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (!isGrounded && Input.GetKey(KeyCode.LeftControl))
        {
            //agachamento
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            atacando = true;
        }
        else 
        {
            atacando = false;
        }
    }
}