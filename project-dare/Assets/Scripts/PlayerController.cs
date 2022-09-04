using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;
using Lean.Gui;

public class PlayerController : MonoBehaviour
{
    public LeanJoystick moveJoystick;
    public LeanJoystick lookJoystick;

    public float xSensitivity = 0.5f;
    public float ySensitivity = 0.5f;

    public float moveSpeed = 8f;

    float xRotation;
    float yRotation;

    Rigidbody rb;
    Camera cam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveControl()
    {
        Vector2 delta = moveJoystick.ScaledValue * Time.fixedDeltaTime * moveSpeed;
        Vector3 dir = new Vector3(delta.x, 0, delta.y);

        Vector3 movement = (dir.x * transform.right) + (dir.z * transform.forward);

        rb.MovePosition(rb.position + movement);
    }

    public void LookControl()
    {
        Vector2 delta = lookJoystick.ScaledValue * 1.8f;

        LookPlayer(delta);
    }

    private void LateUpdate()
    {
        Vector2 delta = LeanGesture.GetScaledDelta(LeanTouch.GetFingers(true, false, 1));

        LookPlayer(delta);
    }

    void LookPlayer(Vector2 delta)
    {
        xRotation -= delta.y * ySensitivity;
        yRotation += delta.x * xSensitivity;

        xRotation = Mathf.Clamp(xRotation, -80f, 90f);

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }

}
