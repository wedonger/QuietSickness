using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class cactomove : MonoBehaviour
{
    public Vector2 turn;
    public float sensitivity = .5f;
    public Vector3 deltaMove;
    public float speed = 10;
    public GameObject mover;
    public float movx;
    public float movy;
    public bool isGrounded;
    public float jumpForce = 150f;
    private Rigidbody rb;
    public LayerMask chao;

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
            movx = movx * 1.5f;
            movy = movy * 1.5f;
        }

        deltaMove = new Vector3(movx, 0, movy) * Time.deltaTime * 2;
        mover.transform.Translate(deltaMove);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.2f);

        if (!isGrounded)
        {
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        else 
        {
            turn.y = 0;
        }

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (!isGrounded && Input.GetKey(KeyCode.LeftControl))
        {
            //agachamento
        }
    }
}