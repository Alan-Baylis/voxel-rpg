using Assets.Source;
using UnityEngine;

namespace Assets.source
{
    public class MainCamera : MonoBehaviour
    {
        private GameObject _focusedTarget;

        // Camera settings
        private float _cameraDistance;
        
        // Use this for initialization
        void Start ()
        {
            _focusedTarget = GameManager.GetInstance().Hero;
            _cameraDistance = 7f;
        }
	
        // Update is called once per frame
        void Update ()
        {
            FollowTarget();
            MouseScroll();
        }

        private void FollowTarget()
        {

            var targetTransformComponent = _focusedTarget.GetComponent<Transform>();
            var vx = (targetTransformComponent.position.x - transform.position.x) / 10;
            var vz = (targetTransformComponent.position.z - transform.position.z - _cameraDistance) / 10;
            transform.Translate(vx, 0, vz);

            var targetHead = new Vector3(targetTransformComponent.position.x, targetTransformComponent.position.y, 5);
            var targetRotation = Quaternion.LookRotation(targetHead - transform.position);
            targetRotation.y = 0;
            targetRotation.z = 0;
            transform.rotation = targetRotation;
        }

        private void MouseScroll()
        {
            var delta = Input.GetAxis("Mouse ScrollWheel");
            _cameraDistance += delta;
        }
    }
}
