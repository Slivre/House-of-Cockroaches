using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CT_IsGrounded : ConditionTask {
		public float GroundCheckRadius;
		public BBParameter<Transform> GroundCheckTrans;

		public LayerMask obsticalLayer;

		public bool isGrounded;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
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
			Collider[] colliders = Physics.OverlapSphere(GroundCheckTrans.value.position, GroundCheckRadius, obsticalLayer);
			isGrounded = colliders.Length > 0 ? true : false;

			return isGrounded;
		}
	}
}