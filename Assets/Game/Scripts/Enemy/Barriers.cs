using UnityEngine;

public class Barriers : MonoBehaviour {

    private Player _player;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.name == "Player") {
            _player.Damage();
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name == "Player") {
            _player.Damage();
        }
    }
}
