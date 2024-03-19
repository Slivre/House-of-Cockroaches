using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_Move : ActionTask {

        Rigidbody rb;
        public float Speed;

        public float GroundCheckRadius;
        public Vector3 GroundCheckOffset;
        Vector3 GroundCheckDrawPos;

        public LayerMask obsticalLayer;

        public bool isGrounded;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            rb = agent.GetComponent<Rigidbody>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            GroundCheckDrawPos = agent.transform.position + GroundCheckOffset;
            Collider[] colliders = Physics.OverlapSphere(GroundCheckDrawPos, GroundCheckRadius, obsticalLayer);
            isGrounded = colliders.Length > 0 ? true : false;

            if (isGrounded)
            {
                Debug.Log("Move");
                rb.velocity = agent.transform.right * Speed;
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}