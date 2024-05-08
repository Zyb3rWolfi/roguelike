using UnityEngine;

namespace DefaultNamespace
{
    public class cameraScript : MonoBehaviour
    {
        public Transform target;
        public float smoothSpeed = 0.125f;
        public Vector3 offset;
        
        void Start()
        {
        }

        void FixedUpdate()
        {
            Vector3 targetCamPos = target.position + offset;
            targetCamPos.z = -10;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothSpeed * Time.deltaTime);
        }
    }
}