using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    public Transform Character;
    private NavMeshAgent agent;
    int health = 100;
    public Rigidbody bullet;
    public Transform spawner;
    bool isShoot = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(shoot());
    }

    void Update()
    {
        RaycastHit hit;
        Vector3 distance = this.transform.position - Character.transform.position;
        distance.y = 0;
        if (Physics.Linecast (this.transform.position, Character.transform.position, out hit, 1)) {
            if (hit.transform.CompareTag ("Character")) {
                if (distance.magnitude > 5) {
                    this.transform.Translate(Vector3.forward * 2f * Time.deltaTime);
                    this.transform.LookAt(Character.transform);
                    isShoot = false;
                }
                else
                {
                    isShoot=true;
                    this.transform.LookAt(Character.transform);
                }
            }
        }
        if(health < 1) {
            this.gameObject.SetActive (false);
        }
        agent.destination = Character.position * 0.1f;
    }

    IEnumerator shoot ()
    {
        yield return new WaitForSeconds(0.75f);
        if (isShoot)
        {
            Rigidbody clone;
            clone = (Rigidbody)Instantiate(bullet, spawner.transform.position, Quaternion.identity);
            clone.velocity = spawner.TransformDirection(Vector3.forward * 10000 * Time.deltaTime);
        }
        StartCoroutine(shoot());
    }

    void OnTriggerEnter(Collider coll) {
        if (coll.gameObject.tag == "Bullet") {
            health -= 20;
        }
    }
}