using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevels : MonoBehaviour {

    public Transform playerTransform;
    public GameObject[] levelsArray;
    private int levelIndex;
    private int levelsAmount;

    private float currentLevelLength;
    public float CurrentLevelLength { get { return currentLevelLength; }  set { currentLevelLength = value; } }

    private float nextLevelLength;

    private float spawnPosition;

    private Vector2 firstChildPos;
    private Vector2 lastChildPos;

    private LevelsBehavior levelsBehavior;

    private GameObject[] objectPool;

    private void Awake() {
        levelsAmount = levelsArray.Length;
        currentLevelLength = 7f;


        //foreach (var level in levelsArray) {
        //    Instantiate(level, Vector2.zero, Quaternion.identity);
        //}
    }

    private void Start() {
        //sInstantiateLevels();
        SpawnLevel();
    }

    public void InstantiateLevels() {
        objectPool = new GameObject[levelsAmount];
        for (int i = 0; i < levelsAmount; i++) {
            GameObject instance = Instantiate(levelsArray[i]);
            instance.SetActive(false);
            objectPool[i] = instance;
            instance.transform.parent = transform;
        }
    }
    
    public GameObject SpawnFromPool(int level_index, Vector2 position, Quaternion rotation) {

        if (objectPool[level_index].activeInHierarchy) {
            return null;
        }

        GameObject objectToSpawn = objectPool[level_index];

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    public void SpawnLevel() {
        levelIndex = Random.Range(0, levelsAmount);   // choose level to spawn

        nextLevelLength = GetLevelLength(levelIndex);

        levelsBehavior = levelsArray[levelIndex].GetComponent<LevelsBehavior>();
        spawnPosition = playerTransform.position.y + currentLevelLength + nextLevelLength / 2f +
            levelsBehavior.zeroYPosition;

        GameObject level = Instantiate(levelsArray[levelIndex], new Vector2(0f, spawnPosition), Quaternion.identity);
        //levelsArray[levelIndex].transform.position = new Vector2(0f, spawnPosition);
        //levelsArray[levelIndex].SetActive(true);

        //GameObject level = SpawnFromPool(levelIndex, new Vector2(0f, spawnPosition), Quaternion.identity);

        if (level == null) {
            SpawnLevel();
        }

        currentLevelLength = nextLevelLength;
    }

    public float GetLevelLength(int level_index) { 
        Transform levelTransform = levelsArray[level_index].transform;
        int lastChildIndex = levelTransform.childCount - 1;

        firstChildPos = levelTransform.GetChild(lastChildIndex - 1).position;
        lastChildPos = levelTransform.GetChild(lastChildIndex).position;

        return lastChildPos.y - firstChildPos.y;
    }
}
