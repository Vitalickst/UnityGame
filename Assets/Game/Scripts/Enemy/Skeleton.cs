using UnityEngine;

public class Skeleton : Enemy, IDamageable {

    public new int Health { get; set; }

    public override void Init() {
        base.Init();
        Health = base.Health;
    }

    public override void Movement() {
        base.Movement();
    }

    public void Damage() {
        if (IsDead) {
            return;
        }

        Debug.Log("Skeleton::Damage");
        Health--;
        Animator.SetTrigger("Hit");
        IsHit = true;
        Animator.SetBool("InCombat", true);

        if (Health < 1) {
            IsDead = true;
            Animator.SetTrigger("Death");
            GameObject diamond = Instantiate(DimondPrefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().Gems = base.Gems;
        }
    }

    private void Shoot() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 50f);
        if (hit.collider.gameObject.name == "Player") {
            Animator.SetBool("InCombat", true);
        } else if (hit.collider.gameObject.name != "Player") {
            Animator.SetBool("InCombat", false);
        }
    }
}
