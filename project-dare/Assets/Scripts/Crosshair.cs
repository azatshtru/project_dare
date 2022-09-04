using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public bool isActive = true;

    public Color baseColor;
    public Color activeColor;

    private float range;
    private LayerMask mask;

    private UnityEngine.UI.RawImage crosshairImage;

    private void Start()
    {
        crosshairImage = GetComponent<UnityEngine.UI.RawImage>();
    }

    void FixedUpdate()
    {
        if (!isActive) { return; }

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, range, mask))
        {
            crosshairImage.color = Color.Lerp(crosshairImage.color, activeColor, 0.15f);
        }
        else
        {
            crosshairImage.color = Color.Lerp(crosshairImage.color, baseColor, 0.15f);
        }
    }

    public void SetCrosshair(float rangeToSet, LayerMask maskToFilter)
    {
        range = rangeToSet;
        mask = maskToFilter;
    }
}
