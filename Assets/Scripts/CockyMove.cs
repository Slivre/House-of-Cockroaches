using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockyMove : MonoBehaviour
{
    Rigidbody rb;
    public float Speed;

    public float GroundCheckRadius;
    public Vector3 GroundCheckOffset;
    Vector3 GroundCheckDrawPos;

    public LayerMask obsticalLayer;

    public bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        GroundCheckDrawPos = transform.position + GroundCheckOffset;
        Collider[] colliders = Physics.OverlapSphere(GroundCheckDrawPos, GroundCheckRadius, obsticalLayer);
        isGrounded = colliders.Length > 0 ? true : false;

        if(isGrounded)
        {
            Debug.Log("Move");
            rb.velocity = transform.right * Speed;
        }
    }

    private void OnDrawGizmos()
    {
        
        Gizmos.DrawWireSphere(GroundCheckDrawPos, GroundCheckRadius);
    }
}
