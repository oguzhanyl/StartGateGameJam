using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Status : MonoBehaviour
{
    public int health = 2; // Düþmanýn baþlangýç caný

    public void TakeDamage(int damage)
    {
        health -= damage; // Caný azalt
        Debug.Log($"{gameObject.name} has {health} health remaining.");

        // Eðer can 0 veya daha azsa düþmaný yok et
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} öldü!");
        Destroy(gameObject); // Nesneyi yok et
    }
}
