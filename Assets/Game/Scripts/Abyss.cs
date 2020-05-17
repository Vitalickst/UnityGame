using UnityEngine;

public class Abyss : MonoBehaviour {

    public AlpfaController AlpfaController;
    protected Player Player;

    private void Start() {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Player.Health = 0;
        Player.PlayerAnimation.Jump(true);
        Player.BackgroundMusic.Stop();
        Player.DeathSound.Play();
        Player.YouDiedSound.Play();
        UIManager.Instance.ClearLives();
        AlpfaController.DeathPanelActive();       
    }
}
