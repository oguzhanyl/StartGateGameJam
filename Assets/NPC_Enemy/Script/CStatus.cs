using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EngineerHP : MonoBehaviour
{
    [SerializeField] public float cHealth, maxHealt = 100f;
    public TextMeshProUGUI HealthText;

    // Start is called before the first frame update
    void Start()
    {
        cHealth = maxHealt;
    }

    public void CTakeDamage(float damageAmount)
    {
        cHealth -= damageAmount;
        Debug.Log($"Engineer {1} hasar aldý. SAÐLIK: {cHealth}");
        HealthText.text = cHealth.ToString();

        if (cHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("StartScreen");

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
}
