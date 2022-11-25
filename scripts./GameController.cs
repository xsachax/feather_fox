using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public bool gameHasEnded = false;
    public GameOverScript GameOverScript;

    // Start is called before the first frame updat

    void Start() {
        Destroy(GameObject.Find("Layout"), 10);
    }

    public void GameOver() {

        if (gameHasEnded==false) {
            gameHasEnded = true;
            GameOverScript.Setup();
        }
    }
}
