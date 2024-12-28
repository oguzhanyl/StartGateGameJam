using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Transform Character;       // Hedef karakter
    private NavMeshAgent agent;       // NPC'nin NavMesh ajaný
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 distance = this.transform.position - Character.position;
        distance.y = 0; // Y eksenindeki farký yok sayýyoruz

        if (distance.magnitude >= 15 && distance.magnitude <= 80)
        {
            agent.isStopped = false;
            agent.destination = Character.position;
            this.transform.LookAt(Character);
            animator.SetBool("isRunning", true);
        }
        else if (distance.magnitude > 80)
        {
            agent.isStopped = true;
        }
        else
        {
            // Ateþ etme konumunda
            agent.isStopped = true; // Yaklaþtýðýnda dur
            this.transform.LookAt(Character); // Hedefe dön
            animator.SetBool("isRunning", false);
            animator.SetBool("isShootAni", true);
        }
    }
}