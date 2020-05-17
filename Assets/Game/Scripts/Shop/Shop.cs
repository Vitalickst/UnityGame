using UnityEngine;

public class Shop : MonoBehaviour {

    public GameObject ShopPanel;
    public int CurrentSelectedItem;
    public int CurrentItemCost;

    private Player _player;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _player = other.GetComponent<Player>();

            if (_player != null) {
                UIManager.Instance.OpenShop(_player.Diamonds);
            }

            ShopPanel.SetActive(true);
        }    
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            ShopPanel.SetActive(false);
        }
    }

    public void SelectItem(int item) {
        switch (item) {
            case 0:
                UIManager.Instance.UpdateShopSelection(65);
                CurrentSelectedItem = 0;
                CurrentItemCost = 200;
                break;
            case 1:
                UIManager.Instance.UpdateShopSelection(-32);
                CurrentSelectedItem = 1;
                CurrentItemCost = 400;
                break;
            case 2:
                UIManager.Instance.UpdateShopSelection(-122);
                CurrentSelectedItem = 2;
                CurrentItemCost = 100;
                break;
        }
    }

    public void BuyItem() {
        if (_player.Diamonds >= CurrentItemCost) {
            if (CurrentSelectedItem == 2) {
                GameManager.Instance.HasKeyToCastle = true;
            }

            _player.Diamonds -= CurrentItemCost;
            ShopPanel.SetActive(false);
        }
        else {
            ShopPanel.SetActive(false);
        }
    }
}
