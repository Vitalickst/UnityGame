using UnityEngine;

public class AcidEffect : MonoBehaviour {

    private void Start() {
        Destroy(this.gameObject, 3.0f);    
    }

    private void Update() {
        transform.Translate(Vector3.right * 3 * Time.deltaTime);    
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            IDamageable hit = other.GetComponent<IDamageable>();

            hit?.Damage();
            Destroy(this.gameObject);
        }
    }
}
