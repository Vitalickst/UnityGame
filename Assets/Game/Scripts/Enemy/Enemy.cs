using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public GameObject DimondPrefab;

    [SerializeField] protected int Health;
    [SerializeField] protected float Speed;
    [SerializeField] protected int Gems;
    [SerializeField] protected Transform PointA, PointB;

    protected Vector3 CurrentTarget;
    protected Animator Animator;
    protected SpriteRenderer SpriteRenderer;
    protected Player Player;

    protected bool IsHit = false;
    protected bool IsDead = false;

    public virtual void Init() {
        Animator = GetComponentInChildren<Animator>();
        SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Start() {
        Init();
    }

    public virtual void Update() {
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && Animator.GetBool("InCombat") == false) {
            return;
        }

        if (IsDead == false) {
            Movement();
        }
    }

    public virtual void Movement() {

        SpriteRenderer.flipX = CurrentTarget == PointA.position;

        if (transform.position == PointA.position) {
            CurrentTarget = PointB.position;
            Animator.SetTrigger("Idle");
        } else if (transform.position == PointB.position) {
            CurrentTarget = PointA.position;
            Animator.SetTrigger("Idle");
        }

        if (IsHit == false) {
            transform.position = Vector3.MoveTowards(transform.position, CurrentTarget, Speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, Player.transform.localPosition);
        if (distance > 2.0f) {
            IsHit = false;
            Animator.SetBool("InCombat", false);
        }

        Vector3 direction = Player.transform.localPosition - transform.localPosition;

        if (direction.x > 0 && Animator.GetBool("InCombat")) {
            SpriteRenderer.flipX = false;
        } else if (direction.x < 0 && Animator.GetBool("InCombat")) {
            SpriteRenderer.flipX = true;
        }
    }
}
