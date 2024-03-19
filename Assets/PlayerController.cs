using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float Xmove;
    float ZMove;
    public float speed;

    public CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {   
    }

    // Update is called once per frame
    void Update()
    {
        Xmove = Input.GetAxis("Horizontal") * speed;
        ZMove = Input.GetAxis("Vertical") * speed;

        Vector3 move = transform.right * Xmove + transform.forward * ZMove;

        characterController.Move(move * speed * Time.deltaTime);
    }
}
