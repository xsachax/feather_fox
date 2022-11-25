using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private const float player_distance = 30f;
    [SerializeField] private List<Transform> levelPartList;
    [SerializeField] private Transform levelPart_Start;
    [SerializeField] private Transform player;
    private Vector3 lastEndPosition;
    private float speed;

    
    private void Awake() {
        lastEndPosition = levelPart_Start.Find("EndPosition").position;

        int startingSpawnLevelParts = 0;
        for(int i=0; i<startingSpawnLevelParts; i++){
            SpawnLevelPart();
        }
    }

    void Start() {
        speed = GameObject.Find("Player").GetComponent<PlayerScript>().playerSpeed;
    }


    void Update() {
        if (Vector3.Distance(player.position, lastEndPosition) < player_distance) {
            SpawnLevelPart();
        }
       }
    

    void SpawnLevelPart() {
        Transform chosenLevelPart = levelPartList[Random.Range(0, levelPartList.Count)];
        Transform lastLevelPartTransform = SpawnLevelPart(chosenLevelPart, lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
        Destroy(lastLevelPartTransform.gameObject, 180/speed);

    }

    private Transform SpawnLevelPart(Transform levelPart, Vector3 spawnPosition) {
        Transform levelPartTransform = Instantiate(levelPart, spawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
