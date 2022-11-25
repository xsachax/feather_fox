using UnityEngine.UI;
using UnityEngine;

public class ControlsPopUp : MonoBehaviour
{
    public LeanTweenType ease;
    public GameObject mainTarget;

    void Awake(){
        LeanTween.reset();
        transform.localScale = new Vector3(0, 0, 0);
    }

    void Update(){
        if (mainTarget.activeSelf == true){
            BoardUp();
        }
    }

    public void BoardUp(){
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.5f).setEase(ease);
    }

    public void Disable(){
        mainTarget.SetActive(false);
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.reset();
    }
}
