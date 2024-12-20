using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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

        if (distance.magnitude >= 15 && distance.magnitude <= 40)
        {
            agent.isStopped = false;
            // Karaktere do�ru hareket
            agent.destination = Character.position;
            isShoot = true;
            this.transform.LookAt(Character);
        }
        else if (distance.magnitude > 40 && distance.magnitude <= 80)
        {
            isShoot = false;
            agent.isStopped = false;
            agent.destination = Character.position;
            this.transform.LookAt(Character);
        }
        else if (distance.magnitude > 80)
        {
            isShoot = false;
            agent.isStopped = true;
        }
        else
        {
            // Ate� etme konumunda
            agent.isStopped = true; // Yakla�t���nda dur
            isShoot = true;
            this.transform.LookAt(Character); // Hedefe d�n
        }
    }

    public IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            if (isShoot)
            {
                // klon mermi olu�tur ve hareket ettir
                Rigidbody clone = Instantiate(bullet, spawner.position, spawner.rotation);
                clone.velocity = (Character.position - spawner.position).normalized * 40f; // Hedefe do�ru h�zland�r
                Destroy(clone.gameObject, 1f); // 1 saniye sonra yok et
            }
        }
    }
}