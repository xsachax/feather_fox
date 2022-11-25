using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape) && GameObject.Find("Player").GetComponent<PlayerScript>().isDead == false){
            if (GameIsPaused) {
                Resume();
            } else
            {
                Pause();
            }
            }
        

        if (GameIsPaused && Input.GetKeyDown(KeyCode.Space)){
            Resume();
        }
    }

    public void ReturnToMenu() {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    
}
