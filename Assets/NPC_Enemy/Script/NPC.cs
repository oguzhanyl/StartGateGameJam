using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Transform Character;       // Hedef karakter
    private NavMeshAgent agent;       // NPC'nin NavMesh ajaný
    public Rigidbody bullet;          // Mermi prefabý
    public Transform spawner;         // Merminin spawn noktasý
    bool isShoot = false;             // Ateþ etme durumu

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Shoot());
    }

    void Update()
    {
        Vector3 distance = this.transform.position - Character.position;
        distance.y = 0; // Y eksenindeki farký yok sayýyoruz

        if (distance.magnitude >= 5)
        {
            agent.isStopped = false;
            // Karaktere doðru hareket
            agent.destination = Character.position;
            isShoot = true;
        }
        else
        {
            // Ateþ etme konumunda
            agent.isStopped = true; // Yaklaþtýðýnda dur
            isShoot = true;
            this.transform.LookAt(Character); // Hedefe dön
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.75f);

            if (isShoot)
            {
                // klon mermi oluþtur ve hareket ettir
                Rigidbody clone = Instantiate(bullet, spawner.position, spawner.rotation);
                clone.velocity = (Character.position - spawner.position).normalized * 20f; // Hedefe doðru hýzlandýr
                Destroy(clone.gameObject, 1.2f); // 1.2 saniye sonra yok et
            }
        }
    }
}