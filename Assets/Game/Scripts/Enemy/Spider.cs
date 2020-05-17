using UnityEngine;

public class Spider : Enemy, IDamageable {

    public GameObject AcidEffectPrefab;
    public new int Health { get; set; }

    public override void Init() {
        base.Init();

        Health = base.Health;
    }
  
    public override void Update() {
        Shoot();
    }

    public void Damage() {
        if (IsDead) {
            return;
        }

        Health--;
        if (Health < 1) {
            IsDead = true;
            Animator.SetTrigger("Death");
            GameObject diamond = Instantiate(DimondPrefab, transform.position, Quaternion.identity);
            diamond.GetComponent<Diamond>().Gems = base.Gems;
        }
    }

    public void Attack() {
        Instantiate(AcidEffectPrefab, transform.position, Quaternion.identity);
    }

    private void Shoot() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 100f);
        if (hit.collider.gameObject.name == "Player") {
            Debug.Log("Hit on " + hit.collider.gameObject.name);
            Animator.SetBool("InCombat", true);
        }
        else {
            Animator.SetBool("InCombat", false);
        }
    }
}
