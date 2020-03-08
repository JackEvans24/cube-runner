using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Score score;
    public GameObject gameOverText;
    public GameObject restartText;
    public GameObject completeLevelUI;

    public bool endlessMode = false;
    public bool gameHasEnded = false;

    protected void Update() {
        if (gameHasEnded && Input.GetButtonDown("Jump"))
            Restart();
        else if (gameHasEnded && endlessMode && Input.GetButtonDown("Cancel"))
            SceneManager.LoadScene(0);
    }

    public void CompleteLevel() {
        if (!gameHasEnded)
            completeLevelUI.SetActive(true);
    }

    public void EndGame() {
        if (gameHasEnded)
            return;

        gameHasEnded = true;
        score.enabled = false;

        Invoke("ShowGameOver", 0.5f);
    }

    void ShowGameOver() {
        if (gameHasEnded) {
            gameOverText.SetActive(true);
            Invoke("ShowHint", 1.5f);
        }
    }

    void ShowHint() {
        if (gameHasEnded)
            restartText.SetActive(true);
    }

    void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
