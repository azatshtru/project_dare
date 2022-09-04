using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeBehaviour : AWeapon
{
    Animator anim;
    AudioSource audioPlayer;

    public AudioClip swingSound;
    public AudioClip hitSound;

    float range = 1.45f;
    bool canAttack = true;

    private void Start()
    {
        anim = GetComponent<Animator>();
        audioPlayer = GetComponent<AudioSource>();
    }

    public override void InitializeCrosshair(Crosshair crosshair)
    {
        crosshair.SetCrosshair(range, LayerMask.GetMask("hitable"));
    }

    public override void BeginAttack()
    {
        if (!canAttack) { return; }

        canAttack = false;
        anim.SetBool("Attack", true);
        StartCoroutine(Attack());
        StartCoroutine(StopAttack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.14f);

        audioPlayer.clip = swingSound;
        audioPlayer.Play();

        yield return new WaitForSeconds(0.08f);

        RaycastHit hit;

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.gameObject.name);
            audioPlayer.clip = hitSound;
            audioPlayer.Play();
        }
    }

    IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(0.98f);
        anim.SetBool("Attack", false);

        canAttack = true;
    }
}
