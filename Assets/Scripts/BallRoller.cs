using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallRoller : MonoBehaviour
{

    public float acceleration = 10;
    private GameObject food;
    private Rigidbody rb;
    private int counter;

    public Transform ballCamera;

    public Text countText;
    public Text winText;
    public float targetTime = 10.0f;

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

        targetTime -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Smallest"))
            {
                food = other.gameObject;
                Destroy(food);
                transform.localScale *= 1.1f;
                counter++;
            }

            if (other.CompareTag("Smaller") && counter >= 1)
            {
                food = other.gameObject;
                Destroy(food);
                transform.localScale *= 1.1f;
                counter++;
            }
            if (other.CompareTag("Small") && counter >= 2)
            {
                food = other.gameObject;
                Destroy(food);
                transform.localScale *= 1.1f;
                counter++;
            }
            if (other.CompareTag("Medium") && counter >= 3)
            {
                food = other.gameObject;
                Destroy(food);
                transform.localScale *= 1.1f;
                counter++;
            }
        }

    }