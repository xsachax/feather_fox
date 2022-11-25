using UnityEngine;

public class MainMenuParallax : MonoBehaviour
{
    public GameObject item;
    public GameObject prevItem;
    private GameObject tempItem;
    public float moveValue;


    void FixedUpdate()
    {
        item.transform.position -= new Vector3(-2 * Time.deltaTime, 0, 0);
        prevItem.transform.position -= new Vector3(-2 * Time.deltaTime, 0, 0);

        if (item.transform.position.x > 75f){
            item.transform.position += new Vector3(moveValue, 0, 0);
            tempItem = item;
            item = prevItem;
            prevItem = tempItem;
        }
    }

/*
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition; 
        transform.position += deltaMovement * parallaxMultiplier;
        lastCameraPosition = cameraTransform.position;
    }
    */
}
