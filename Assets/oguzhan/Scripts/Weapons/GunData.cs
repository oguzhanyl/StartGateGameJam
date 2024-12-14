using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewGunData", menuName = "Gun/GunData")]
public class GunData : ScriptableObject
{
    public string gunName;

    public LayerMask targetLayerMask;

    [Header("Fire Config")]
    public float shootingRange;
    public float fireRate;

    [Header("Reload Config")]
    public float magazineSize;
    public float reloadTime;

    [Header("Aim Recoil Settings")]
    public float a_recoilAmount;
    public Vector2 a_maxRecoil;
    public float a_recoilSpeed;
    public float a_resetRecoilSpeed;

    [Header("Directional Recoil Settings")]
    public float d_recoilAmount;
    public Vector2 d_maxRecoil;
    public float d_recoilSpeed;
    public float d_resetRecoilSpeed;
}
