using UnityEngine;

public class MossGiant : Enemy, IDamageable {

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

        Debug.Log("MossGiant::Damage");
        Health--;
        Animator.SetTrigger("Hit");
        IsHit = true;
        Animator.SetBool("InCombat", true);

        if (Health < 1) {
            IsDead = true;
            Animator.SetTrigger("Death");
            GameObject diamond = Instantiate(DimondPrefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().Gems = Gems;
        }
    }
}
