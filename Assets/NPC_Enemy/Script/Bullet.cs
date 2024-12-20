using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<EngineerHP>(out EngineerHP engineerComponent))
        {
            engineerComponent.CTakeDamage(1);
        }
    }
}