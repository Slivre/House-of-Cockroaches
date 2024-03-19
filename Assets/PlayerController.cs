using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float Xmove;
    float ZMove;

    Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Xmove = Input.GetAxisRaw("Horizontal") * speed;
        ZMove = Input.GetAxisRaw("Vertical") * speed;

        Debug.DrawRay(transform.position, transform.forward * 999f, Color.blue);
    }

    private void FixedUpdate()
    {
        Vector3 XMovement = transform.right * Xmove;
        Vector3 ZMovement = transform.forward * ZMove;

        rb.velocity = XMovement + ZMovement;
    }
}
