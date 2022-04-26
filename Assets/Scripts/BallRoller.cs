using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    public float acceleration = 10;

    private Rigidbody rb;

    public Transform ballCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveLeftRight = Input.GetAxis("Horizontal");
        float moveForwardBack = Input.GetAxis("Vertical");

        Vector3 xAcceleration = ballCamera.right * moveLeftRight * Time.deltaTime * acceleration;
        Vector3 forward = ballCamera.forward;
        forward.y = 0;
        forward.Normalize();
        Vector3 zAcceleration = ballCamera.forward * moveForwardBack * Time.deltaTime * acceleration;

        rb.velocity += xAcceleration + zAcceleration;
    }
}
