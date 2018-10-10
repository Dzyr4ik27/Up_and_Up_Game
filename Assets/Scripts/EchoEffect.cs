using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour  {

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    ObjectPooler objectPooler;

    private void Start() {
        objectPooler = ObjectPooler.Instance;
    }

    private void Update() {
        if (timeBtwSpawns <= 0f) {
            GameObject obj = objectPooler.SpawnFromPool("Echo", transform.position, Quaternion.identity);
            obj.SetActive(false);
            obj.SetActive(true);
            timeBtwSpawns = startTimeBtwSpawns;
        } else {
            timeBtwSpawns -= Time.deltaTime; 
        }
    }
}
