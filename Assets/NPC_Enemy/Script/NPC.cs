using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Transform Character;       // Hedef karakter
    private NavMeshAgent agent;       // NPC'nin NavMesh ajan�
    public Rigidbody bullet;          // Mermi prefab�
    public Transform spawner;         // Merminin spawn noktas�
    bool isShoot = false;             // Ate� etme durumu

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(Shoot());
    }

    void Update()
    {
        Vector3 distance = this.transform.position - Character.position;
        distance.y = 0; // Y eksenindeki fark� yok say�yoruz

        if (distance.magnitude >= 5)
        {
            agent.isStopped = false;
            // Karaktere do�ru hareket
            agent.destination = Character.position;
            isShoot = true;
        }
        else
        {
            // Ate� etme konumunda
            agent.isStopped = true; // Yakla�t���nda dur
            isShoot = true;
            this.transform.LookAt(Character); // Hedefe d�n
        }
    }

    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.75f);

            if (isShoot)
            {
                // klon mermi olu�tur ve hareket ettir
                Rigidbody clone = Instantiate(bullet, spawner.position, spawner.rotation);
                clone.velocity = (Character.position - spawner.position).normalized * 20f; // Hedefe do�ru h�zland�r
                Destroy(clone.gameObject, 1.2f); // 1.2 saniye sonra yok et
            }
        }
    }
}