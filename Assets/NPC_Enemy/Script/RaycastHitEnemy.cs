using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitExample : MonoBehaviour
{
    public float rayDistance = 100f; // Raycast'in mesafesi
    public int Cdamage = 1;          // Verilen hasar

    void Update()
    {
        if (Input.GetButtonUp("Fire1")) // Sol t�klama ile tetiklenir
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // E�er bir nesneye �arparsa
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // �arpt��� nesnenin tag'i "Enemy" ise
                if (hit.collider.CompareTag("Enemy"))
                {
                    // EnemyHealth script'ini al
                    Enemy_Status enemyHealth = hit.collider.GetComponent<Enemy_Status>();

                    // E�er EnemyHealth varsa can azalt
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(Cdamage);
                    }
                }
            }
        }
    }
}
