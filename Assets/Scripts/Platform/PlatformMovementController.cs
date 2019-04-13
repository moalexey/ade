using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Platform
{
    public class PlatformMovementController : MonoBehaviour 
    {

        public float PlatformSpeed;

        public GameObject Platform;

        public Transform CurrentPoint;

        public Transform[] Points;

        public int PointSelection;


        // Use this for initialization
        void Start () 
        {
            CurrentPoint = Points[PointSelection];
        
        }
    
        // Update is called once per frame
        void Update () 
        {
            Platform.transform.position = Vector3.MoveTowards(Platform.transform.position, CurrentPoint.position, Time.deltaTime * PlatformSpeed);

            if (Platform.transform.position == CurrentPoint.position)
            {
                PointSelection++;
                if (PointSelection == Points.Length)
                {
                    PointSelection = 0;
                }
                CurrentPoint = Points[PointSelection];
            }
        }
    }
}