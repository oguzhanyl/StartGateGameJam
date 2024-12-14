using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gun : MonoBehaviour
{
    public GunData gunData;
    public Transform gunMuzzle;

    private WeaponAnim weaponAnim;
    private CinemachineImpulseSource recoilShakeImpulseSource;

    public GameObject bulletHolePrefab;
    public GameObject bulletHitParticlePrefab;

    public AudioSource audioSource;

    [SerializeField] GameObject muzzleFlash;
    [SerializeField] GameObject explosions;
    [SerializeField] GameObject smoke;
    [HideInInspector] public bool isShooting = false;

    [HideInInspector] public PlayerMovement playerController;
    [HideInInspector] public Transform cameraTransform;

    private float currentAmmo = 0f;
    private float nextTimeToFire = 0f;

    private Vector3 d_targetRecoil = Vector3.zero;
    [HideInInspector] public Vector3 d_currentRecoil = Vector3.zero;

    private bool isReloading = false;

    private void Start()
    {
        currentAmmo = gunData.magazineSize;

        playerController = transform.root.GetComponent<PlayerMovement>();
        cameraTransform = playerController.virtualCamera.transform;
        weaponAnim = GetComponent<WeaponAnim>();

        audioSource = GetComponent<AudioSource>();
        recoilShakeImpulseSource = GetComponent<CinemachineImpulseSource>();
    }

    public virtual void Update()
    {
        playerController.ResetAimRecoil(gunData);
        ResetDirectionalRecoil();

        MuzzleFlash(isShooting);
    }

    public void TryReload()
    {
        if (!isReloading && currentAmmo < gunData.magazineSize)
        {
            StartCoroutine(Reload());
        }
    }

    private IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log(gunData.gunName + " is reloading...");

        yield return new WaitForSeconds(gunData.reloadTime);

        currentAmmo = gunData.magazineSize;
        isReloading = false;

        Debug.Log(gunData.gunName + " is reloaded");
    }

    public void TryShoot()
    {
        if (isReloading)
        {
            Debug.Log(gunData.gunName + " is reloading...");
            return;
        }

        if(currentAmmo <= 0f)
        {
            Debug.Log(gunData.gunName + " has no bullets left, Please reload");
            return;
        }

        if(Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + (1 / gunData.fireRate);
            HandleShoot();
        }
    }

    private void HandleShoot()
    {
        isShooting = true;

        currentAmmo--;

        // recoil();
        // muzzleFlash();

        Debug.Log(gunData.gunName + " Shot!, Bullets left: " + currentAmmo);
        Shoot();

        playerController.ApplyAimRecoil(gunData);
        ApplyDirectionalRecoil();
        weaponAnim.isRecoiling = true;
        recoilShakeImpulseSource.GenerateImpulse();

        PlayFireSound();
    }

    public abstract void Shoot();

    public void ApplyDirectionalRecoil()
    {
        float recoilX = Random.Range(-gunData.a_maxRecoil.x, gunData.a_maxRecoil.x) * gunData.a_recoilAmount;
        float recoilY = Random.Range(-gunData.a_maxRecoil.y, gunData.a_maxRecoil.y) * gunData.a_recoilAmount;

        d_targetRecoil += new Vector3(recoilX, recoilY, 0);

        d_currentRecoil = d_targetRecoil;
    }

    public void ResetDirectionalRecoil()
    {
        d_currentRecoil = Vector3.MoveTowards(d_currentRecoil, Vector3.zero, Time.deltaTime * gunData.a_resetRecoilSpeed);
        d_targetRecoil = Vector3.MoveTowards(d_targetRecoil, Vector3.zero, Time.deltaTime * gunData.a_resetRecoilSpeed);
    }

    private void MuzzleFlash(bool activate)
    {
        muzzleFlash.SetActive(activate);
        explosions.SetActive(activate);
        smoke.SetActive(activate);
    }

    private void PlayFireSound()
    {
        if(gunData.fireSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(gunData.fireSound);
        }
    }

}
