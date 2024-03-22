using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CT_IsSeen : ConditionTask {
		public bool InvertCheck;

		public float SenseDistance;
		public BBParameter<Renderer> renderer;

		public bool DelayCheck;
		public float delay;
		float currentDelay;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			currentDelay = 0;
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//If delay check is checked, delay the checking time.
            if (DelayCheck)
            {
				currentDelay += Time.deltaTime;
				if (currentDelay > delay)
                {
					//Check if cocky is in sight of camera by checking if it is being rendered.
					return renderer.value.isVisible;
				}
				//Invert checking condition
				return InvertCheck;
            }
            else
            {
				return renderer.value.isVisible;
			}
		}
	}
}