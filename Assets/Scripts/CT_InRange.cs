using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CT_InRange : ConditionTask {
		public BBParameter<Transform> Target;
		public float InRangeDistance;

		public bool TargetIsPlayer;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			if (TargetIsPlayer)
			{
				Target.value = GameObject.Find("Player").transform;
			}
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {

		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
            if (Vector3.Distance(Target.value.position, agent.transform.position)<= InRangeDistance)
            {
				return true;
            }
            else
            {
				return false;
			}
		}
	}
}