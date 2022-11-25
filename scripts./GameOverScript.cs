using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{   
    public Text scoreText;
    public Text highScoreText;

    public float currentScore;
    public float highScore;



    void Update() {
        if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space)){
            LoadScene1();
        }

        if (gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape)){
            LoadMainMenu();
        }
    }

    public void LoadScene1() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }




    public void Setup() {
        GameObject.Find("ScoreText").GetComponent<PlayerScore>().stopCount +=1;

        GameObject theScore = GameObject.Find("ScoreText");
        currentScore = theScore.GetComponent<PlayerScore>().floatScore;       // gather text values from other scripts
        GameObject thePlayer = GameObject.Find("ScoreText");
        highScore = thePlayer.GetComponent<PlayerScore>().floatHighScore; /// get high score

        scoreText.text = currentScore.ToString("0");
        highScoreText.text = highScore.ToString("0");
        gameObject.SetActive(true);
    
    }
}
