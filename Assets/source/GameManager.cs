using UnityEngine;

namespace Assets.Source
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _singleton;

        public GameObject WorldCamera = null;
        public GameObject Hero = null;

        public SkinnedMeshRenderer HeroMesh = null;
        public SkinnedMeshRenderer ActiveItem = null;


        // Use this for initialization
        void Start ()
        {
            _singleton = this;
            Debug.Log("==== Game Start ====");

            SkinnedMeshRenderer itemMesh = Instantiate<SkinnedMeshRenderer>(ActiveItem);
            itemMesh.transform.parent = HeroMesh.transform;
            itemMesh.bones = HeroMesh.bones;
            itemMesh.rootBone = HeroMesh.rootBone;

        }

        public static GameManager GetInstance()
        {
            if (_singleton == null)
            {
                _singleton = new GameManager();
            }

            return _singleton;
        }


        // Update is called once per frame
        void Update () {
		
        }
    }
}
