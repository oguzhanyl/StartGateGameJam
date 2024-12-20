using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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

        if (distance.magnitude >= 15 && distance.magnitude <= 40)
        {
            agent.isStopped = false;
            // Karaktere doðru hareket
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
            // Ateþ etme konumunda
            agent.isStopped = true; // Yaklaþtýðýnda dur
            isShoot = true;
            this.transform.LookAt(Character); // Hedefe dön
        }
    }

    public IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            if (isShoot)
            {
                // klon mermi oluþtur ve hareket ettir
                Rigidbody clone = Instantiate(bullet, spawner.position, spawner.rotation);
                clone.velocity = (Character.position - spawner.position).normalized * 40f; // Hedefe doðru hýzlandýr
                Destroy(clone.gameObject, 1f); // 1 saniye sonra yok et
            }
        }
    }
}