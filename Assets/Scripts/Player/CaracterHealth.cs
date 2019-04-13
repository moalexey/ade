using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace Scripts.Player
{
    public class CaracterHealth : MonoBehaviour
    {
        private Rigidbody2D myRB;
        public GameObject DeathFX;
        public Transform SpawnPoint;

        // Use this for initialization
        void Start()
        {
            myRB = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {


        }


        public void MakeDead()
        {
            if (myRB.transform.position != SpawnPoint.position)
            {
                Instantiate(DeathFX, transform.position, transform.rotation);
            }
            
            myRB.gameObject.GetComponent<SpriteRenderer>().enabled = false;            
            foreach (Collider2D c in GetComponents<Collider2D>())
            {
                c.enabled = false;
            }
            //myRB.transform.position = SpawnPoint.position;

            StartCoroutine(RestartLevel());

            
        }

        IEnumerator RestartLevel()
        {
            yield return new WaitForSeconds(0.4f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(myRB.gameObject);
        }
    }
}
