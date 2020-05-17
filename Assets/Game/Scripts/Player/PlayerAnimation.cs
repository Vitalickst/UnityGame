using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator _playerAnimator;

    private void Start() {
        _playerAnimator = GetComponentInChildren<Animator>();
    }

    public void Move(float move) {
        _playerAnimator.SetFloat("Move", Mathf.Abs(move));
    }

    public void Jump(bool jumping) {
        _playerAnimator.SetBool("Jumping", jumping);
    }

    public void Attack() {
        _playerAnimator.SetTrigger("Attack");
    }

    public void Death() {
        _playerAnimator.SetTrigger("Death");
    }

    public void Hit() {
        _playerAnimator.SetTrigger("Hit");
    }
}
