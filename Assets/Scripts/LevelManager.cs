using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

namespace Scripts.Levels
{
    public class LevelManager : MonoBehaviour 
    {
        /*
        // Update is called once per frame
        void Update () 
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        */

        void OnTriggerEnter2D(Collider2D changeScene)
        {
            if  (changeScene.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
