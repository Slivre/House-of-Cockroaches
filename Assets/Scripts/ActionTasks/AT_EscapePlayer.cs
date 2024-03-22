using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_EscapePlayer : ActionTask {
		public BBParameter<float> speed;
		public BBParameter<Transform> Player;

		public float initialSpeed;

		public bool AttackInstead;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			Player.value = GameObject.Find("Player").transform;
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			speed.value = initialSpeed;

			Vector3 DirToRun = Player.value.position - agent.transform.position;

			// Calculate the angle in radians
			float angleRadians = Mathf.Atan2(DirToRun.z, DirToRun.x);

			float angleDegrees = 0;

			//Go towards or away from player based on if its attack or escape
			if (!AttackInstead)
            {
				angleDegrees = -angleRadians * Mathf.Rad2Deg;
			}
            else
            {
				angleDegrees = angleRadians * Mathf.Rad2Deg;
			}
			//Rotate towards the set angle, ONLY on y axis
			agent.transform.rotation = Quaternion.AngleAxis(angleDegrees, -agent.transform.up);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}