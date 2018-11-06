using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script needs to have a sprite renderer

public class Delete : MonoBehaviour
{
    public bool isChild;
    public float timeToDelete;

    private void OnBecameInvisible() {
        if (isChild) {
            Invoke("DeleteParent", timeToDelete);
        } else {
            Invoke("DeleteObject", timeToDelete);
        }
    }

    public void DeleteObject() {
        Destroy(gameObject);
    }

    public void DeleteParent() {
        Destroy(transform.parent.gameObject);
    }
}
