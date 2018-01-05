using Assets.source.enums;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.source.person
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class MovementMotor : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;
        // Use this for initialization
        void Start () {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 moveToTargetPosition)
        {
            _navMeshAgent.SetDestination(moveToTargetPosition);
        }
    }
}
