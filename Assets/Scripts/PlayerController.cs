using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    public float movespeed;
    public float sprintspeed;
    private float speed;
    public Transform tr;
    
    public void Walk()
    {
        speed = movespeed;
    }

    public void Sprint()
    {
        speed = sprintspeed;
    }

    public void Crouch()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        speed = movespeed;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Sprint();
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift) | Input.GetKeyUp(KeyCode.LeftControl))
        {
            Walk();
        }

        moveInput = new Vector3(0f, 0f, Input.GetAxisRaw("Vertical")* Time.deltaTime);
        moveVelocity = moveInput * movespeed;
        transform.position += transform.forward * Input.GetAxis("Vertical")*Time.deltaTime * speed;
        transform.position += transform.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed;
    }
}
