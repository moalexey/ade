using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemy
{

    public class EnemyDamage : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Scripts.Player.CaracterHealth thePlayerHealth = other.gameObject.GetComponent<Scripts.Player.CaracterHealth>();
                thePlayerHealth.MakeDead();

            }
        }
    }
}