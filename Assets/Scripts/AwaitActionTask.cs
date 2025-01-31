using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions{

	public class AwaitActionTask : ActionTask{
		public float maxWaitTime;
		public float minWaitTime;

		private float timeRemaining;

		protected override string OnInit(){
            return null;
		}


		protected override void OnExecute(){
			timeRemaining = UnityEngine.Random.Range(minWaitTime, maxWaitTime);
		}


		protected override void OnUpdate(){
			timeRemaining -= Time.deltaTime;
			if (timeRemaining <= 0)
			{
				EndAction(true);
			}
			//Wait a random amount of time between two values
        }

        //Called when the task is disabled.
        protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}