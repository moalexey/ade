using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Enemy
{
    public class EnemyMovementController : MonoBehaviour {

        public float MaxSpeed;

        private bool moveRight = false;
        public GameObject enemyGraphic;


        // Use this for initialization
        void Start () {
            
        }
        
        // Update is called once per frame
        void FixedUpdate () {
            if(moveRight)
            {
                transform.Translate(Vector3.right * MaxSpeed);                
            }       
            else
            {
                transform.Translate(Vector3.left * MaxSpeed);
            }
        }


        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.tag == "Ground")
            {          
                moveRight = !moveRight;
                flipFacing();
            }
        }

        void flipFacing()
        {
            if (enemyGraphic != null)
            {
                float facingX = enemyGraphic.transform.localScale.x;
                facingX *= -1f;
                enemyGraphic.transform.localScale = new Vector3(facingX, enemyGraphic.transform.localScale.y, enemyGraphic.transform.localScale.z);
            }
        }
    }
}