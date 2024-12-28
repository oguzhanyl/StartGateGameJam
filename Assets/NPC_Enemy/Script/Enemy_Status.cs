using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Status : MonoBehaviour
{
    public int health = 2; // D��man�n ba�lang�� can�
    private static int i;
    public Animator animator;
    public bool isDead = false;
    public void TakeDamage(int damage)
    {
        if(isDead) return;
        health -= damage; // Can� azalt
        Debug.Log($"{gameObject.name} has {health} health remaining.");

        // E�er can 0 veya daha azsa d��man� yok et
        if (health <= 0)
        {
            Die();
            i++;
            if (i == 10)
            {
                SceneManager.LoadScene("end");
            }
        }
    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger("DieEnemy");
        StartCoroutine(DestroyAfterAnimation());

        Debug.Log($"{gameObject.name} �ld�!");
        Debug.Log($"Toplam �ld�r�len d��man say�s�: {i}");
    }
    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(2f);

        // GameObject'i yok et
        Destroy(gameObject);
    }

    //IEnumerator wait()
    //{
    //    yield return new WaitForSeconds(2f); // Bu �al���r
    //}
}
