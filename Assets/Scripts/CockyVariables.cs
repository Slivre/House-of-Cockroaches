using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CockyVariables : MonoBehaviour
{
    public Animator animator;
    public Transform FrontRayPos;
    public Renderer CockyRenderer;


    public float GroundCheckRadius;
    public Transform GroundCheckTrans;
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GroundCheckTrans.position, GroundCheckRadius);
    }

    //Animation event methods
    public void StopEating()
    {
        animator.SetBool("Eating", false);
    }
}
