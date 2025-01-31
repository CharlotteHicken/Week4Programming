using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;
using System.Drawing;

namespace NodeCanvas.Tasks.Actions{

	public class SearchActionTask : ActionTask{

        public float searchRadius;

        private NavMeshAgent navAgent;

        protected override string OnInit(){
            navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		protected override void OnExecute(){
            Vector3 randomPoint = Random.insideUnitSphere * searchRadius + agent.transform.position;

			NavMeshHit navMeshHit;
			if(NavMesh.SamplePosition(randomPoint, out navMeshHit, searchRadius, NavMesh.AllAreas))
			{
				return;
			}

			navAgent.SetDestination(navMeshHit.position);
        }

		protected override void OnUpdate(){
			
			if(navAgent.pathPending && navAgent.remainingDistance <= navAgent.stoppingDistance)
			{
				EndAction(true);
			}
        }

        //Called when the task is disabled.
        protected override void OnStop(){
			
		}

		//Called when the task is paused.
		protected override void OnPause(){
			
		}
	}
}