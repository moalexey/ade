using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.UI
{
    public class PauseMenu : MonoBehaviour 
    {
        public string LevelSelect;
        public string MainMenu;

        public bool IsPaused;
        public GameObject PauseMenuCanvas;
        public GameObject AudioManager;

        // Use this for initialization
        void Start () {
            
        }
        
        // Update is called once per frame
        void Update () 
        {
            if (IsPaused)
            {
                PauseMenuCanvas.SetActive(true);
                Time.timeScale = 0f;
                AudioManager.GetComponent<RichUnity.Audio.AudioManager>().SoundOn = false;
                AudioManager.GetComponent<RichUnity.Audio.AudioManager>().MusicOn = false;
            }
            else
            {
                PauseMenuCanvas.SetActive(false);
                Time.timeScale = 1f;
                AudioManager.GetComponent<RichUnity.Audio.AudioManager>().SoundOn = true;
                AudioManager.GetComponent<RichUnity.Audio.AudioManager>().MusicOn = true;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                IsPaused = !IsPaused;
            }
            
        }

        public void Resume()
        {
            IsPaused = false;
        }

        public void SelectLevel()
        {
            SceneManager.LoadScene(LevelSelect);
        }

        public void Quit()
        {
            SceneManager.LoadScene(MainMenu);
        }
    }
}
