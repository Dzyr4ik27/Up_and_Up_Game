using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject player;

    private float timeToRestart = 2f;

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }
    }


    private void OnEnable() {
        PlayerCollision.OnPlayerDied += OnPlayerDied;
    }

    private void OnDisable() {
        PlayerCollision.OnPlayerDied -= OnPlayerDied;
    }

    public void OnPlayerDied() {
        player.transform.GetChild(0).gameObject.SetActive(false);
        player.transform.GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(2).gameObject.SetActive(true);

        //camera.GetComponent<CameraBehavior>().enabled = false;

        Invoke("RestartLevel", timeToRestart);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
