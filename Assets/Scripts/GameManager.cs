using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
