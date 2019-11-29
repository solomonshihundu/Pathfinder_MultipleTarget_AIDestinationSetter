using UnityEngine;

namespace Pathfinding {
	
	[UniqueComponent(tag = "ai.destination")]
	public class AIDestinationSetter : VersionedMonoBehaviour {
		/// <summary>The object that the AI should move to</summary>
		public Transform target;

        //Maximum distance to target
        public float maxDist = 10;

        //collection of all targets
        public Transform[] targets;

        //AI object declaration
        IAstarAI ai;


    void OnEnable () {
			ai = GetComponent<IAstarAI>();
			
			if (ai != null) ai.onSearchPath += Update;
		}

		void OnDisable () {
			if (ai != null) ai.onSearchPath -= Update;
		}

		/// <summary>Updates the AI's destination every frame</summary>
		void Update ()
        {

            float distance_exit_1 = Vector3.Distance(transform.position, targets[0].position);
            float distance_exit_2 = Vector3.Distance(transform.position, targets[1].position);
            Debug.Log("DISTANCE ONE....." + distance_exit_1);
            Debug.Log("DISTANCE TWO....." + distance_exit_2);

            if ( ai != null)
            {
               
                /*
                 * Going through all the objetcs in the array 
                 * set the object closest to our transform as 
                 * the target.
                 */
                foreach (Transform myTarget in targets)
                {
                    float distance = Vector3.Distance(myTarget.position, transform.position);

                    if (distance < maxDist)
                    {
                        target = myTarget;
                        ai.destination = target.position;
                    }
                }

            }
        }
	}
}
