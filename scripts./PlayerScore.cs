using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    public Transform player;
    public float floatScore = 0;
    public float floatHighScore;
    public Text scoreText;
    
    private int i = 100;
    public bool x = true;
    public bool y = true;

    public int stopCount = 0;

    public GameObject neww;
    
    void Start ()
    {
        neww.SetActive(false);
        floatHighScore = PlayerPrefs.GetInt("HighScore1", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopCount == 0)
        {
        neww.SetActive(false);
        floatScore = (player.position.x * 10);
        scoreText.text = floatScore.ToString("0");


        if (floatScore > PlayerPrefs.GetInt("HighScore1", 0)) {
            PlayerPrefs.SetInt("HighScore1", (int)floatScore);
            floatHighScore = floatScore;
            neww.SetActive(true);
        }
        }


        if (player.transform.position.x > i) {
            FlashTextAlpha();
            Invoke("FlashTextAlpha", 0.2f);
            Invoke("FlashTextAlpha", 0.4f);
            Invoke("FlashTextAlpha", 0.6f);
            Invoke("FlashTextAlpha", 0.8f);
            Invoke("FlashTextAlpha", 1.0f);
            i+=100;
            
        }
    }

    /* DELETE SAVED HIGH_SCORE
    public void Reset () {
        PlayerPrefs.DeleteKey("HighScore");
    }
    */

    void FlashTextAlpha() {
        if (x == true){
            gameObject.GetComponent<Text>().color = new Color32(50, 50, 50, 0);
            x=false;
        }
        else if (x == false){
            gameObject.GetComponent<Text>().color = new Color32(50, 50, 50, 255);
            x=true;
        }
    }
}

