using Assets.source.enums;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.source.person
{
    public class MovementAnimator : MonoBehaviour
    {
        private Animator _animator;

        private NavMeshAgent _navMeshAgent;
        // Use this for initialization
        void Start () {
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update ()
        {
            float speedPercent = _navMeshAgent.velocity.magnitude / _navMeshAgent.speed;
            _animator.SetFloat("speedPercent", speedPercent, .1f, Time.deltaTime);
        }
    }
}
