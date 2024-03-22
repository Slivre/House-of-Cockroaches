using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_Eat : ActionTask {
		public BBParameter<Animator> ac;
		public BBParameter<float> speed;
		public BBParameter<Transform> FoodPos;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			speed.value = 0;
			ac.value.SetBool("Eating", true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			//Check if Food still exists, in case another cockroach eats it before this one
            if (FoodPos.value != null)
            {
				//Destroy the eaten food
				GameObject.Destroy(FoodPos.value.gameObject);
			}
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}