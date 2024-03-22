using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CT_CheckPlayerMove : ConditionTask {
		public Transform Player;

		Vector3 PlayerPosLastTick;

		public float ReactWhenDistGreater;

		public float TickEvery;
		float CurrentTick;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			Player = GameObject.Find("Player").transform;
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			PlayerPosLastTick = Player.position;
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {

		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			CurrentTick += Time.deltaTime;
			if (CurrentTick > TickEvery)
			{
				float DistanceMoved = Vector3.Distance(Player.position, PlayerPosLastTick);
				if(DistanceMoved> ReactWhenDistGreater)
                {
					return true;
				}
                else
                {
					PlayerPosLastTick = Player.position;
				}
				CurrentTick = 0;
			}
			return false;
		}
	}
}