using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Services;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_Move : ActionTask {

        Rigidbody rb;
        public BBParameter<float> speed;
        public BBParameter<Transform> Player;

        public float GroundCheckRadius;
        public BBParameter<Transform> GroundCheckTrans;

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
            Player.value = GameObject.Find("Player").transform;
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {               
            Collider[] colliders = Physics.OverlapSphere(GroundCheckTrans.value.position, GroundCheckRadius, obsticalLayer);
            isGrounded = colliders.Length > 0 ? true : false;  

            //If it is not grounded, switch to fly mode.
            if (!isGrounded)
            {
                ac.value.SetBool("Flying", true);
            }
            //If is grounded, walk
            else
            {
                ac.value.SetBool("Flying", false);
            }

            MoveTowards();
            ClimbWalls();
            ac.value.SetFloat("Speed", speed.value);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

        /// <summary>
        /// Move function without target, move forward
        /// </summary>
        public void MoveTowards()
        {
            rb.velocity = agent.transform.right * speed.value;
        }



        //Climb Walls
        public void ClimbWalls()
        {
            //Draw Front Ray
            Debug.DrawRay(FrontCheck.value.position, agent.transform.right*999,Color.cyan);
            Ray frontRay = new Ray(FrontCheck.value.position, agent.transform.right);

            //If front ray hit a  obstical
            if (Physics.Raycast(frontRay, out hit, FrontCheckDist, obsticalLayer))
            {
                //Find and Rotate it towards the perpendicular angle to stick on wall
                Vector3 cross = Vector3.Cross(agent.transform.right, hit.normal);
                float Zangle = Vector3.Angle(agent.transform.right, cross);
                agent.transform.Rotate(0, 0, Zangle);            
            }

            //Cast a ray from the bottom of the cockroach
            Ray BotRay = new Ray(agent.transform.position, -agent.transform.up);
            //If bot ray hit a obstical
            if (Physics.Raycast(BotRay, out hit, 0.5f, obsticalLayer))
            {
                //Added some force towards the bottom direction to help cocky stick.
                rb.AddForce(-agent.transform.up * 2);
            }

                //Draw a ray pointing towards the bottom.
                Debug.DrawRay(agent.transform.position, -agent.transform.up * 0.5f, Color.green);
        }        
	}
}