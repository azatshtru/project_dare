using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Gui;

public class WeaponController : MonoBehaviour
{
    public Transform crosshairHolder;
    public Crosshair defaultCrosshair;

    public LeanButton interactButton;
    public LeanJoystick shootJoystick;

    private AWeapon currentWeapon;
    private Crosshair currentCrosshair;

    float weaponEquipRange = 1.25f;

    private void Start()
    {
        if(currentWeapon == null)
        {
            SetDefaultCrosshair();
        }
    }

    public void TryEquip()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, weaponEquipRange, LayerMask.GetMask("weaponitem")))
        {
            WeaponItem weaponItem = hit.transform.GetComponent<WeaponItem>();
            GameObject weaponGO = Instantiate(weaponItem.GetWeapon(), transform);
            currentWeapon = weaponGO.GetComponent<AWeapon>();
            interactButton.gameObject.SetActive(false);
            shootJoystick.gameObject.SetActive(true);

            Destroy(currentCrosshair.gameObject);
            currentCrosshair = Instantiate(weaponItem.GetCrosshair(), crosshairHolder);
            currentWeapon.InitializeCrosshair(currentCrosshair);

            weaponItem.DestroySelf();           
        }
    }

    public void UnequipWeapon()
    {
        Destroy(currentWeapon.gameObject);
        currentWeapon = null;
        interactButton.gameObject.SetActive(true);
        shootJoystick.gameObject.SetActive(false);

        Destroy(currentCrosshair.gameObject);
        SetDefaultCrosshair();
    }

    public void Attack()
    {
        if(currentWeapon == null) 
        {
            return; 
        }
        currentWeapon.BeginAttack();
    }

    void SetDefaultCrosshair()
    {
        currentCrosshair = Instantiate(defaultCrosshair, crosshairHolder);
        currentCrosshair.SetCrosshair(weaponEquipRange, LayerMask.GetMask("weaponitem"));
    }
}
