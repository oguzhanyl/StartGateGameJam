using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Status : MonoBehaviour
{
    public int health = 2; // Düþmanýn baþlangýç caný
    private static int i;
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

        i++; // Tüm düþmanlarýn ortak `i` deðeri
        Debug.Log($"Toplam öldürülen düþman sayýsý: {i}");

        if (i==10)
        {
            SceneManager.LoadScene("end");
        }
    }
}
