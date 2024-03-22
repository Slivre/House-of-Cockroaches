using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_GoToFood : ActionTask {
		public BBParameter<float> speed;
		public BBParameter<Transform> FoodPos;

		public float InitialSpeed;

		public float AdjustTime;
		float currentAdjustTime;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			speed.value = InitialSpeed;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//get the direction of the target's and cocky
			Vector3 targetDir = (agent.transform.position - FoodPos.value.position).normalized;
			//Remove the y axis, because cockroaches move on flat surfaces.
			Vector3 Dir2D = new Vector3(targetDir.x,0, targetDir.z);
			//Project this direction on a plane based on cocky's bottom direction
			Vector3 Dir2DDown = Vector3.ProjectOnPlane(Dir2D, -agent.transform.up);

			Debug.DrawRay(agent.transform.position, -Dir2DDown * 999f, Color.red);

			//Re-Direct every certain amount of time.
			currentAdjustTime += Time.deltaTime;
			if(currentAdjustTime > AdjustTime)
            {
				MoveTowards(-Dir2DDown);
				currentAdjustTime = 0;
			}
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		/// <summary>
		/// Move function with target, rotate towards target, then move forward
		/// </summary>
		public void MoveTowards(Vector3 target)
		{
			// Calculate the angle in radians
			float angleRadians = Mathf.Atan2(target.z, target.x);

			// Convert radians to degrees
			float angleDegrees = angleRadians * Mathf.Rad2Deg;

			agent.transform.rotation = Quaternion.AngleAxis(angleDegrees, -agent.transform.up);
		}
	}
}