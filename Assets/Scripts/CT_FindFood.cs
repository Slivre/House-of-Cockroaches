using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CT_FindFood : ConditionTask {
		public BBParameter<Transform> FoodPos;
		public LayerMask foodLayers;
		public float SearchRadius;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			FoodPos.value = null;
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//Find food in a certain range
			Collider[] FoodFound = Physics.OverlapSphere(agent.transform.position, SearchRadius, foodLayers);

			//If any was found......
			if (FoodFound.Length > 1)
            {
				//Check which is closet
				float closestDist = 999f;
				foreach(Collider food in FoodFound)
                {
					//Get the distance between cocky and food
					float Dist2Food = Vector3.Distance(food.transform.position, agent.transform.position);
					//If it is the current closest, set it to the food to go for.
                    if (Dist2Food < closestDist)
                    {
						closestDist = Dist2Food;
						FoodPos = food.transform;
                    }
                }
				return true;
			}
			return false;
		}
	}
}