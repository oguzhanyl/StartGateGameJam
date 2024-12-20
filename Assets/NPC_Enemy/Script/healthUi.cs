using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI elemanlar�na eri�mek i�in gerekli

public class PlayerHealthUI : MonoBehaviour
{
    public Text healthText; // Can� g�sterecek Text bile�eni
    public EngineerHP engineerHP; // Can de�erinin bulundu�u script

    void Update()
    {
        if (engineerHP != null && healthText != null)
        {
            // cHealth de�erini Text UI'ye g�ncelle
            healthText.text = "Health: " + engineerHP.cHealth.ToString();
        }
    }
}

