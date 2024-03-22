using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_StareContest : ActionTask {
		public BBParameter<float> speed;
		public float InitialSpeed;

		public BBParameter<int> StateChoice;

		Rigidbody rb;
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
			//Try to land
			rb.AddForce(Vector3.down * 100f);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//Chose a random state base on int
			StateChoice.value = Random.Range(1, 3);
			speed.value = InitialSpeed;
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}