using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public float timeToStart;
    private float minTime = 0f;
    private float maxTime = 1f;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
        //timeToStart = Random.Range(minTime, maxTime);
    }

    private void Start() {
        Invoke("StartAnimation", timeToStart);
    }

    public void StartAnimation() {
        animator.enabled = true;
    }
}
