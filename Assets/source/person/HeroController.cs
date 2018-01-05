using Assets.source.enums;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.source.person
{
    [RequireComponent(typeof(MovementMotor))]
    public class HeroController : MonoBehaviour
    {
        public LayerMask LayerMask;

        private Camera _mainCamera;
        private MovementMotor _movementMotor;

        // Use this for initialization
        void Start()
        {
            _mainCamera = Camera.main;
            _movementMotor = GetComponent<MovementMotor>();
        }

        // Update is called once per frame
        void Update ()
        {
            ProcessMovementInput();
        }

        public void ProcessMovementInput()
        {
            if (Input.GetMouseButtonDown(0)) // left Click
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, LayerMask))
                {
                    _movementMotor.MoveTo(hit.point);
                }
            }
        }

        private void Animate(AnimationEnums animationAction)
        {
            var animator = GetComponent<Animator>();
            switch (animationAction)
            {
                case AnimationEnums.Walk:
                    //animator.Play("hero_walkcycle");
                    animator.Play("hero_walksmooth");
                    break;
                case AnimationEnums.Idle:
                default:
                    animator.Play("hero_idle");
                    break;
            }
        }
    }
}
