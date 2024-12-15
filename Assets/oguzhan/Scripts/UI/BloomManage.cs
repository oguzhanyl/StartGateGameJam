using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomManage : MonoBehaviour
{
    public Volume globalVolume;
    private Bloom bloom;

    [SerializeField] private float minIntensity = 0f;
    [SerializeField] private float maxIntensity = 0.5f;
    [SerializeField] private float speed = 2.0f;

    private void Start()
    {
        globalVolume.profile.TryGet<Bloom>(out bloom);
    }

    private void Update()
    {
        if (bloom != null)
        {
            float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.Sin(Time.time * speed) + 1) / 2;
            bloom.intensity.value = intensity;
        }
    }
}
