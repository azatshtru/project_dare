using UnityEngine;

public abstract class AWeapon: MonoBehaviour
{
    public abstract void InitializeCrosshair(Crosshair crosshair);
    public abstract void BeginAttack();
}
