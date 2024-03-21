using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.Rendering;


namespace NodeCanvas.Tasks.Conditions {

	public class CT_CheckSeen : ConditionTask {

		public BBParameter<Renderer> renderer;

		//This is a struct that invovlves a ton of math that I do not quite understand
		//But in short in contains useful Color and Lighting data which is obtained
		//from Light Probes, which I can use to compare in order to find what the brightness
		// around a  certain area is.
		SphericalHarmonicsL2 LightProbesData = new SphericalHarmonicsL2();

		[Tooltip("What value of brightness would be considered to be in shadow?")]
		public float ShadowBrightness;

		public bool InShadow;

		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			InShadow = false;
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			//Get Lighting data from light probes
			LightProbes.GetInterpolatedProbe(agent.transform.position, renderer.value, out LightProbesData);

			//Get value from the down direction(shadows) of a lightprobe
			Vector3[] direction = new Vector3[]{ Vector3.down };
			//Color value to return
			Color[] ambientLight = new Color[1];

			//find r,g,b from LightProbesData for the down direction.
			LightProbesData.Evaluate(direction, ambientLight);

			//Use standard luminance formula to calculate the returned brightness
			float brightness =	0.2126f * ambientLight[0].r + 0.7152f * ambientLight[0].g + 0.0722f * ambientLight[0].b;

			Debug.Log(brightness);

			InShadow = brightness < ShadowBrightness ? true : false;

			return InShadow;
		}
	}
}