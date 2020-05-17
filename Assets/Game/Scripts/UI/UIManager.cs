using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    private static UIManager _instance;

    public static UIManager Instance {
        get {
            if (_instance == null) {
                Debug.LogError("UI Manager is Null");
            }
            return _instance;
        }
    }

    public Text PlayerGemCountText;
    public Image SelectionImg;
    public Text GemCountText;
    public Image[] HealthBars;

    public void OpenShop(int gemCount) {
        PlayerGemCountText.text = "" + gemCount + "G";
    }

    public void UpdateShopSelection(int yPos) {
        SelectionImg.rectTransform.anchoredPosition = new Vector2(SelectionImg.rectTransform.anchoredPosition.x, yPos);
    }
 
    private void Awake() {
        _instance = this;
    }

    public void UpdateGemCount(int count) {
        GemCountText.text = "" + count;
    }

    public void UpdateLives(int livesRemaining) {
        for (int i = 0; i <= livesRemaining; i++) {
            if (i == livesRemaining) {
                HealthBars[i].enabled = false;
            }
        }
    }

    public void ClearLives() {
        foreach (var t in HealthBars) {
            t.enabled = false;
        }
    }
}
