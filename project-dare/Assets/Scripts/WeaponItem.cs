using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{
    public GameObject weaponToEquip;

    public Crosshair crosshair;

    public GameObject GetWeapon()
    {
        return weaponToEquip;
    }

    public Crosshair GetCrosshair()
    {
        return crosshair;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

}
