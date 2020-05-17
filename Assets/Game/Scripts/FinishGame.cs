using UnityEngine;

public class FinishGame : MonoBehaviour {

    private Player _player;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            _player.IsFinish = true;
            _player.BackgroundMusic.Stop();
        }
    }
}
