using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    Rigidbody rb;
    private InputMaster controls;
    [SerializeField] private float speed = 10f;
    private float rotateSpeed = 0.3f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        controls = new InputMaster();
    }

    public void OnEnable()
    {
        controls.Enable();
    }

    public void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        Vector3 currentPosition = transform.position;
        float forwardMovementInput = controls.Player.ForwardMovement.ReadValue<float>();
        float sideMovementInput = controls.Player.SideMovement.ReadValue<float>();

        if (forwardMovementInput > 0f)
            rb.velocity = transform.forward * speed;
        else if (forwardMovementInput < 0f)
            rb.velocity = -transform.forward * speed;
        else
            rb.velocity = new Vector3(0f, 0f, 0f);

        if (sideMovementInput > 0f)
            rb.velocity = transform.right * speed;
        else if (sideMovementInput < 0f)
            rb.velocity = -transform.right * speed;
    }

    void Rotate()
    {
        float rotateInput = controls.Player.Rotation.ReadValue<float>();
        Vector3 rotatePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // if right
        if(rotateInput > 0f)
            transform.RotateAround(rotatePosition, Vector3.up, rotateSpeed);
        // if left
        if (rotateInput < 0f)
            transform.RotateAround(rotatePosition, -Vector3.up, rotateSpeed);
    }
}
