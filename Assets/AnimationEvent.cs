using System.Collections;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    bool isShoot = true;
    public Rigidbody bullet;          // Mermi prefab�
    public Transform spawner;         // Merminin spawn noktas�
    public Transform Character;

    public void Shoot()
    {
        if (isShoot)
        {
            Rigidbody clone = Instantiate(bullet, spawner.position, spawner.rotation); // klon mermi olu�tur ve hareket ettir
            clone.velocity = (Character.position - spawner.position).normalized * 40f; // Hedefe do�ru h�zland�r
            Destroy(clone.gameObject, 1f); // 1 saniye sonra yok et
        }
    }
}
