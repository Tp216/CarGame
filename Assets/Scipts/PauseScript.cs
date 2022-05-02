using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseScript : MonoBehaviour
{
    private bool PauseEnabled;
    public GameObject Pause;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            if(PauseEnabled == true)
            {
                Time.timeScale = 1;
                PauseEnabled = false;
                Pause.SetActive(false);
            }
            else if (PauseEnabled == false)
            {
                Time.timeScale = 0;
                PauseEnabled = true;
                Pause.SetActive(true);
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
                Scene Scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(Scene.name);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
