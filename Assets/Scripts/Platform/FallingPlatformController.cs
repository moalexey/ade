using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Platform
{
    public class FallingPlatformController : MonoBehaviour {
        
        public float FallDelay;
        public float ShakeCircle;

        private Rigidbody2D myRB;


        // Use this for initialization
        void Start () {
            myRB = GetComponent<Rigidbody2D>();
        }
        
        // Update is called once per frame
        void Update () 
        {
   
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                GetComponent<RichUnity.Audio.SoundSource>().PlaySound();
                StartCoroutine(Fall(FallDelay));
                Destroy(gameObject, FallDelay + 3f);
            }
        }

        IEnumerator Fall(float fallTime)
        {
            // Shake
            while (fallTime > 0)
            {
                myRB.position = new Vector2(
                    myRB.position.x + (Random.insideUnitCircle.x * ShakeCircle),
                    myRB.position.y);
                yield return new WaitForSeconds(0.0001f);
                fallTime -= Time.deltaTime;
            }
            // Fall
            myRB.isKinematic = false;
            GetComponent<Collider2D>().isTrigger = true;
            yield return 0;
        }

    }
}