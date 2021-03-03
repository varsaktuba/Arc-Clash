using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public Trajectory trajectory;
    public GameObject ball;
    public float powerMultiplier;

    private void Update()
    {
        trajectory.Clear();

        Vector3 mousePosition = Input.mousePosition;

        mousePosition.z = 10;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        float power = Vector3.Distance(mousePosition, transform.position);

        Vector3 direction = (mousePosition - transform.position).normalized;

        if (Input.GetMouseButton(0))
        {
            trajectory.Create(transform.position, direction * power * powerMultiplier);

        }

        if (Input.GetMouseButtonUp(0))
        {
            Instantiate(ball, transform.position, Quaternion.identity).GetComponent<Rigidbody>().AddForce(direction * power* powerMultiplier);
        }
    }
}
