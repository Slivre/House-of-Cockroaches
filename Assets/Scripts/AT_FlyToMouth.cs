using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class AT_FlyToMouth : ActionTask {
		public BBParameter<Transform> Player;
		public BBParameter<float> speed;
		Transform camera;
		public float initialSpeed;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			camera = Player.value.Find("Main Camera");
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			speed.value = initialSpeed;
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//Rotate towards camera
			agent.transform.LookAt(camera);
			//Fix rotation problem due to model importing.
			agent.transform.rotation = Quaternion.AngleAxis(90, agent.transform.up);
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}