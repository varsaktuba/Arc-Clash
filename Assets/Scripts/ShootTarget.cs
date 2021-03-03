using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ShootTarget : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(Force: mousePressDownPos - mouseReleasePos);
    }
    private float forceMultiplier = 8;

    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;
        rb.AddForce(new Vector3(Force.x, Force.y, z: Force.y) * forceMultiplier);
        isShoot = true;
       // Spawner.Instance.NewSpawnRequest();
    }
}
