using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour, IDamageable {

    [SerializeField] private float _jumpForce = 5.0f;
    [SerializeField] private float _speed = 5.0f;

    private bool _resetJump = false;
    private Rigidbody2D _rigidbody2D;   
    private SpriteRenderer _playerSpriteRenderer;

    internal PlayerAnimation PlayerAnimation;

    public AudioSource SwordAttackSound;
    public AudioSource JumpUpSound;
    public AudioSource JumpDownSound;
    public AudioSource HitSound;
    public AudioSource DeathSound;
    public AudioSource YouDiedSound;
    public AudioSource DiamondSound;
    public AudioSource BackgroundMusic;
    public GameObject Blood;
    public int Diamonds;    
    public bool IsFinish = false;

    public int Health { get; set; }

    private void Start() {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        PlayerAnimation = GetComponent<PlayerAnimation>();
        _playerSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Health = 4;
    }

    private void Update() {
        Movement();

        if (CrossPlatformInputManager.GetButtonDown("A_Button") && IsGrounded() && Health > 0) { 
            PlayerAnimation.Attack();
            SwordAttackSound.pitch = Random.Range(0.9f, 1.1f);
            SwordAttackSound.Play();
        }
    }

    private void Movement() {
        if (Health < 1) {
            _rigidbody2D.velocity = Vector2.zero;
            return;
        }

        float move = CrossPlatformInputManager.GetAxis("Horizontal"); 
        IsGrounded();

        Flip(move);

        if (CrossPlatformInputManager.GetButtonDown("B_Button") && IsGrounded()) { 
            JumpUpSound.Play();
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
            PlayerAnimation.Jump(true);
            if (IsGrounded()) {
                
            }
        }

        _rigidbody2D.velocity = new Vector2(move * _speed, _rigidbody2D.velocity.y);

        PlayerAnimation.Move(move);
    }

    private bool IsGrounded() {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1f, 1 << 8);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);

        if (hitInfo.collider != null) {
            if (_resetJump == false) {
                PlayerAnimation.Jump(false);
                return true;
            }
        }
        JumpDownSound.Play();
        return false;
    }

    private void Flip(float move) {
        if (move > 0) {
            _playerSpriteRenderer.flipX = false;
        }
        else if(move < 0) {
            _playerSpriteRenderer.flipX = true;
        }
    }

    IEnumerator ResetJumpRoutine() {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }

    public void Damage() {
        if (Health < 1) {
            return;
        }
       
        if (Health > 1) {
            PlayerAnimation.Hit();
            HitSound.Play();
        }

        Instantiate(Blood, transform.position, Quaternion.identity);
        Health--;
        UIManager.Instance.UpdateLives(Health);

        if (Health < 1) {
            Death();
        }
    }

    public void Death() {
        PlayerAnimation.Death();
        BackgroundMusic.Stop();
        DeathSound.Play();
        YouDiedSound.Play();
    }

    public void AddGems(int amount) {
        Diamonds += amount;
        DiamondSound.Play();
        UIManager.Instance.UpdateGemCount(Diamonds);
    }
}
