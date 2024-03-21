using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_GoToFood : ActionTask {
		public BBParameter<float> speed;
		public BBParameter<Transform> FoodPos;
		public BBParameter<Animator> ac;
		public float InitialSpeed;

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
			ac.value.SetBool("Walking", true);
			MoveTowards(FoodPos.value);
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

		/// <summary>
		/// Move function with target, rotate towards target, then move forward
		/// </summary>
		public void MoveTowards(Transform target)
		{
			//Only calculate angle on 2d surface
			Vector2 V2Pos = new Vector2(agent.transform.position.x, agent.transform.position.z);
			Vector2 V2TargetPos = new Vector2(target.position.x, target.position.z);

			agent.transform.Rotate(0, Vector2.Angle(V2Pos, V2TargetPos), 0);
		}
	}
}