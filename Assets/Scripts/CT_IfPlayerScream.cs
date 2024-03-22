using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class CT_IfPlayerScream : ConditionTask {
		public BBParameter<Transform> Player;

		public AudioSource audioSource;

		int sampleDataLength = 1024;
		float[] AudioData;
		public float Sensitivity = 100;
		public float Volume;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			audioSource = Player.value.GetComponent<AudioSource>();
			AudioData = new float[sampleDataLength];
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
			//fills an array of audio sample data base on the current time
			audioSource.clip.GetData(AudioData, audioSource.timeSamples);

			//Add all the data together for a total volume;
			Volume = 0f;
			foreach (float sample in AudioData)
			{
				Volume += Mathf.Abs(sample);
			}
			//Get averge
			Volume /= sampleDataLength;
			//Multiply by sensitivity for a better number
			Volume *= Sensitivity;

            if (Volume > 1)
            {
				return true;
			}

			return false;
		}
	}
}