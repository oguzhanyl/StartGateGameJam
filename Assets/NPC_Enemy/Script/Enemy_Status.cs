using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Status : MonoBehaviour
{
    public int health = 2; // D��man�n ba�lang�� can�

    public void TakeDamage(int damage)
    {
        health -= damage; // Can� azalt
        Debug.Log($"{gameObject.name} has {health} health remaining.");

        // E�er can 0 veya daha azsa d��man� yok et
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name} �ld�!");
        Destroy(gameObject); // Nesneyi yok et
    }
}
