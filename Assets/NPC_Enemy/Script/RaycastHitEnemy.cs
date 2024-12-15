using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHitExample : MonoBehaviour
{
    public float rayDistance = 100f; // Raycast'in mesafesi
    public int Cdamage = 1;          // Verilen hasar

    void Update()
    {
        if (Input.GetButtonUp("Fire1")) // Sol týklama ile tetiklenir
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Eðer bir nesneye çarparsa
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // Çarptýðý nesnenin tag'i "Enemy" ise
                if (hit.collider.CompareTag("Enemy"))
                {
                    // EnemyHealth script'ini al
                    Enemy_Status enemyHealth = hit.collider.GetComponent<Enemy_Status>();

                    // Eðer EnemyHealth varsa can azalt
                    if (enemyHealth != null)
                    {
                        enemyHealth.TakeDamage(Cdamage);
                    }
                }
            }
        }
    }
}
