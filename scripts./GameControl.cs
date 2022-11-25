using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public GameObject controlsObject;

    // Start is called before the first frame updat
    public void OnControlsClick() {
            controlsObject.SetActive(true);
    }

    public void PlayLevel1() {
        SceneManager.LoadScene("Level1");
    }
}
