using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstersBehavior : MonoBehaviour {
    private Animator monsterAnimator;
    static readonly int anim_Blink = Animator.StringToHash("Blink");

    private float time;
    private float lastTimestamp;

    [Range(0,5)]
    public float minBlinkTime = 0;
    [Range(0,5)]
    public float maxBlinkTime = 5;

    private void Awake() {
        monsterAnimator = GetComponent<Animator>();
        time = Random.Range(minBlinkTime, maxBlinkTime);
    }

    private void Update() {
        if (Time.time - lastTimestamp >= time) {
            lastTimestamp = Time.time;
            time = Random.Range(minBlinkTime, maxBlinkTime);
            monsterAnimator.SetTrigger(anim_Blink);

        }
    }


}
