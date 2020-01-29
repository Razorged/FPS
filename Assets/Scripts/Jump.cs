using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpVelocity;
    private Rigidbody rb;
    public CapsuleCollider col;
    public LayerMask groundLayer;
    
    private bool IsGrounded()
    {
       return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.center.y - 0.5f *col.height + 0.8f*col.radius, col.bounds.center.z), col.radius * .9f, groundLayer);
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector3.up * jumpVelocity;
        }
    }
}
