using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI elemanlarýna eriþmek için gerekli

public class PlayerHealthUI : MonoBehaviour
{
    public Text healthText; // Caný gösterecek Text bileþeni
    public EngineerHP engineerHP; // Can deðerinin bulunduðu script

    void Update()
    {
        if (engineerHP != null && healthText != null)
        {
            // cHealth deðerini Text UI'ye güncelle
            healthText.text = "Health: " + engineerHP.cHealth.ToString();
        }
    }
}

