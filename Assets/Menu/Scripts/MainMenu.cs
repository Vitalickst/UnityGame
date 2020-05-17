using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartButton() {
        SceneManager.LoadScene("Level1");
    }

    public void QuitButton() {
        Application.Quit();
    }
}
