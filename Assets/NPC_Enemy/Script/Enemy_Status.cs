using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Status : MonoBehaviour
{
    public int health = 2; // D��man�n ba�lang�� can�
    private static int i;
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

        i++; // T�m d��manlar�n ortak `i` de�eri
        Debug.Log($"Toplam �ld�r�len d��man say�s�: {i}");

        if (i==10)
        {
            SceneManager.LoadScene("end");
        }
    }
}
