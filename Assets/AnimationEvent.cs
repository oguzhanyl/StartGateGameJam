using System.Collections;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    bool isShoot = true;
    public Rigidbody bullet;          // Mermi prefabý
    public Transform spawner;         // Merminin spawn noktasý
    public Transform Character;

    public void Shoot()
    {
        if (isShoot)
        {
            Rigidbody clone = Instantiate(bullet, spawner.position, spawner.rotation); // klon mermi oluþtur ve hareket ettir
            clone.velocity = (Character.position - spawner.position).normalized * 40f; // Hedefe doðru hýzlandýr
            Destroy(clone.gameObject, 1f); // 1 saniye sonra yok et
        }
    }
}
