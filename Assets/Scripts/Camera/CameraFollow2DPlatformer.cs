using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Camera
{
    public class CameraFollow2DPlatformer : MonoBehaviour
    {

        public Transform Target; //what camera is following
        public float Smoothing; //dampening effect

        Vector3 offset;

        float lowY;

        // Use this for initialization
        void Start()
        {
            offset = transform.position - Target.position;

            lowY = transform.position.y;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 targetCamPos = Target.position + offset;

            transform.position = Vector3.Lerp(transform.position, targetCamPos, Smoothing * Time.deltaTime);

            if (transform.position.y < lowY)
            {
                transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
            }
        }
    }

}
