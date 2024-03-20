using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
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

        public BBParameter<Animator> ac;
        public BBParameter<Transform> FrontCheck;
        public float FrontCheckDist;

        RaycastHit hit;

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

            //Draw a ray pointing towards the bottom.
            Debug.DrawRay(agent.transform.position, -agent.transform.up * 10f, Color.green);

            

            //If it is not grounded, switch to fly mode.
            if (!isGrounded)
            {
                rb.velocity = agent.transform.right * Speed * 1.5f;
            }
            //If is grounded, walk
            else
            {
                ac.value.SetBool("Walking", true);
                rb.velocity = agent.transform.right * Speed;
            }

            ClimbWalls();
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

        //Climb Walls
        public void ClimbWalls()
        {

            //Draw Front Ray
            Debug.DrawRay(FrontCheck.value.position, agent.transform.right*999,Color.cyan);
            Ray frontRay = new Ray(FrontCheck.value.position, agent.transform.right);


            //check if there is Object in front
            bool FrontObjectDetected = Physics.Raycast(frontRay,out hit, FrontCheckDist,obsticalLayer);
            //If there is......
            if (FrontObjectDetected)
            {
                //Find and Rotate it towards the perpendicular angle to stick on wall
                Vector3 cross = Vector3.Cross(agent.transform.right, hit.normal);
                float Zangle = Vector3.Angle(agent.transform.right, cross);
                agent.transform.Rotate(0, 0, Zangle);

                
            }

            //Debugging helps
            RaycastHit InfiHit = new RaycastHit();
            bool frontRayInifinite = Physics.Raycast(frontRay, out InfiHit, obsticalLayer);
            if (frontRayInifinite)
            {
                Debug.DrawRay(InfiHit.point, InfiHit.normal * 99f, Color.magenta);
            }


        }


        
	}
}