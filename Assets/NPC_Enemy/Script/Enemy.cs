using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineerHP : MonoBehaviour
{
    [SerializeField] float cHealth, maxHealt = 50f;

    // Start is called before the first frame update
    void Start()
    {
        cHealth = maxHealt;
    }

    public void CTakeDamage(float damageAmount)
    {
        cHealth -= damageAmount;
        Debug.Log($"Engineer {1} hasar aldý. SAÐLIK: {cHealth}");

        if (cHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
