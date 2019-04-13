using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemy
{

    public class EnemySawController : MonoBehaviour
    {
        public float Speed;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.forward * Speed);//Random.Range(5f, 23f));
        }
    }
}