using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AlpfaController : MonoBehaviour {

    public Image ImageDied;
    public Image ImageRestart;
    public Image ImageMenu;
    public Image FinishImagePanel;
    public GameObject DeathsPanel;
    public GameObject FinishPanel;

    protected Player Player;

    private void Start() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update() {
        DeathPanelActive();
        FinishPanelActive();
    }

    public void DeathPanelActive() {
        if (Player.Health < 1) {
            DeathsPanel.SetActive(true);
            ImageDied.color = new Color(ImageDied.color.r, ImageDied.color.g, ImageDied.color.b, ImageDied.color.a + 0.5f * Time.deltaTime);
            ImageRestart.color = new Color(ImageRestart.color.r, ImageRestart.color.g, ImageRestart.color.b, ImageRestart.color.a + 0.5f * Time.deltaTime);
            ImageMenu.color = new Color(ImageMenu.color.r, ImageMenu.color.g, ImageMenu.color.b, ImageMenu.color.a + 0.5f * Time.deltaTime);            
        }
    }

    public void FinishPanelActive() {
        if (Player.IsFinish) {
            FinishPanel.SetActive(true);
            FinishImagePanel.color = new Color(FinishImagePanel.color.r, FinishImagePanel.color.g, FinishImagePanel.color.b, FinishImagePanel.color.a + 0.5f * Time.deltaTime);
            StartCoroutine(Co_WaitForSeconds(3f));
        }
    }

    public void ButtonStart() {
        SceneManager.LoadScene("Level1");
    }

    public void ButtonMenu() {
        SceneManager.LoadScene("Menu");
    }

    private IEnumerator Co_WaitForSeconds(float value) {
        yield return new WaitForSeconds(value);
        SceneManager.LoadScene("Victory");
    }
}
