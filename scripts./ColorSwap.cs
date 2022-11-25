using UnityEngine;
using UnityEngine.UI;

public class ColorSwap : MonoBehaviour
{
    public GameObject player;
    private int randomNumber;
    private int i = 100;
    private int x = 230;

    void Update()
    {
        if (player.transform.position.x > 100){
            if (player.transform.position.x > i/30) { // bigger the division number faster it goes
                gameObject.GetComponent<SpriteRenderer>().color = new Color32((byte)Mathf.Abs(x), (byte)Mathf.Abs(x), (byte)Mathf.Abs(x), 255);
                i+=100;
                if (x == -230) 
                    x = 230;
                if(x == 50)
                    x = -50;
                x-=1;
                
            }
        }
    }
}

