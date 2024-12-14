using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnim : MonoBehaviour
{
    [SerializeField] private float positionalSway = 0.1f;
    [SerializeField] private float rotationalSway = 0.1f;
    [SerializeField] private float swaySmoothness = 1f;

    private Vector3 initialPosition = Vector3.zero;
    private Quaternion initialRotation = Quaternion.identity;

    [Header("Weapon Bobbing")]
    [SerializeField] private float bobbingSpeed = 5f;
    [SerializeField] private float bobbingAmount = 5f;

    private float bobTimer = 0f;
    private PlayerMovement player;

    [Header("Recoil Animation")]
    [SerializeField] private float recoilAmount = 0.2f;
    [SerializeField] private float recoilSmoothness = 5f;

    [HideInInspector] public bool isRecoiling = false;
    private Vector3 currentRecoil = Vector3.zero;

    private void Start()
    {
        player = transform.root.GetComponent<PlayerMovement>();

        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation;
    }

    private void Update()
    {
        ApplySway();
        ApplyBobbing();
        ApplyRecoil();
    }

    private void ApplySway()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 positionOffset = new Vector3(mouseX, mouseY, 0) * positionalSway;
        Quaternion rotationOffset = Quaternion.Euler(new Vector3(-mouseY, -mouseX, mouseX) * rotationalSway);

        transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition - positionOffset, Time.deltaTime * swaySmoothness);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, initialRotation * rotationOffset, Time.deltaTime * swaySmoothness);
    }

    private void ApplyBobbing()
    {
        float moveSpeed = Input.GetAxis("Horizontal") + Input.GetAxis("Vertical");
        float bobOffset = 0f;

        if(moveSpeed > 0.1f && player.controller.isGrounded)
        {
            bobTimer += Time.deltaTime * bobbingSpeed * player.currentSpeedMultiplier;
            bobOffset = Mathf.Sin(bobTimer) * bobbingAmount;
        }

        else
        {
            bobTimer = 0f;
            bobOffset = Mathf.Lerp(bobTimer, 0, Time.deltaTime * swaySmoothness);
        }

        transform.localPosition += new Vector3(0, bobOffset, 0);
    }

    private void ApplyRecoil()
    {
        Vector3 targetRecoil = Vector3.zero;

        if (isRecoiling)
        {
            targetRecoil = new Vector3(0, 0, -recoilAmount);

            if(Vector3.Distance(currentRecoil, targetRecoil) < 0.1f)
            {
                isRecoiling = false;
            }
        }
        currentRecoil = Vector3.Lerp(currentRecoil, targetRecoil, Time.deltaTime * recoilSmoothness);
        transform.localPosition += currentRecoil;
    }
}
