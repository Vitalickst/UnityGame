using UnityEngine;

public class Diamond : MonoBehaviour {

    public int Gems = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            Player player = other.GetComponent<Player>();
            if (player != null) {
                player.AddGems(Gems);
                Destroy(this.gameObject);
            }
        }
    }
}
