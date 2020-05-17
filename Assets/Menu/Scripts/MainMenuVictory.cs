using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Image = UnityEngine.UI.Image;

public class MainMenuVictory : MonoBehaviour {

    public Image BlackPanelIamge;
    public GameObject BlackPanel;


    public void RestartButton() {
        SceneManager.LoadScene("Level1");
    }

    public void MenuButton() {
        SceneManager.LoadScene("Menu");
    }

    public void QuitButton() {
        Application.Quit();
    }

    private void Start() {
        BlackPanel.SetActive(true);
    }

    private void Update() {
        if (Math.Abs(BlackPanelIamge.color.a) > 0) {
            BlackPanelIamge.color = new Color(BlackPanelIamge.color.r, BlackPanelIamge.color.g, BlackPanelIamge.color.b, BlackPanelIamge.color.a - 0.5f * Time.deltaTime);
        }

        if (Math.Abs(BlackPanelIamge.color.a) < 0.001f) {
            BlackPanel.SetActive(false);
        }

    }
}
