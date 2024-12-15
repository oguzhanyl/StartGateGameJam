using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnderlayManage : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    [SerializeField] private float minGlow = 0.5f;
    [SerializeField] private float maxGlow = 1.0f;
    [SerializeField] private float speedGlow = 2.0f;

    private Material textMaterial;
    private float glowValue;

    private void Start()
    {
        textMaterial = textMeshPro.fontMaterial;
        glowValue = minGlow;
    }

    private void Update()
    {
        if(textMeshPro != null)
        {
            glowValue = Mathf.Lerp(minGlow, maxGlow, (Mathf.Sin(Time.time * speedGlow) + 1) / 2);
            textMaterial.SetFloat(ShaderUtilities.ID_GlowOuter, glowValue);
        }
    }
}
