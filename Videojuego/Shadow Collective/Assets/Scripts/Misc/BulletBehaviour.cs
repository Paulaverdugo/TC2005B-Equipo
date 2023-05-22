using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Script to control the bullet behavior
    public float bulletSpeed = 10f;

    private void Update() {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        // Deal damage to the player
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<BasePlayer>().GetDamaged(1);
        }

        // Deal damage to the guard
        if (collision.gameObject.CompareTag("Guard")) {
            collision.gameObject.GetComponent<Guard>().GetDamaged(1);
        }

        Destroy(gameObject);
    }

}
