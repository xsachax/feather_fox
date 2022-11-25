using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopIn : MonoBehaviour
{

    public GameObject target;
    public LeanTweenType easeType;
    private bool x = true;
    
    void Start() {
        LeanTween.reset();
    }

    void Update()
    {
        if (target.activeSelf == true && x == true){
            OnEnable();
        }
        
    }

    public void OnEnable() {
        transform.localScale = new Vector3(0, 0, 0);
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.7f).setDelay(0.1f).setEase(easeType).setOnComplete(Done);
    }

    public void Done(){
        x = false;
    }
}
