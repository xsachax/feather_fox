using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxCam : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    
    public GameObject item;
    public GameObject prevItem;
    public float moveValue;

    public GameObject player1;

    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    void Update()
    {
        if (player1.transform.position.x >  (item.transform.position.x + 10.0)) {
            var tempItem = prevItem;
            prevItem = item;
            tempItem.transform.position += new Vector3(moveValue, 0, 0);
            item = tempItem;
        }

        if (player1.transform.position.x > 1000) {
            parallaxMultiplier = 0.3f;
        }
        else if (player1.transform.position.x > 500) {
            parallaxMultiplier = 0.5f;
        }
        else if (player1.transform.position.x > 200) {
            parallaxMultiplier = 0.7f;
        }

    }

    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition; 
        transform.position += deltaMovement * parallaxMultiplier;
        lastCameraPosition = cameraTransform.position;
    }
}
