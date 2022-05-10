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

    public Text TimerText;

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

    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Smallest"))
            {
                food = other.gameObject;
                Destroy(food);
                counter++;
                TimerText.text = string.Format("{0}", counter);
                if (counter == 2)
                {
                    transform.localScale *= 1.1f;
                    acceleration -= 0.1f;
                } 
            }

            if (other.CompareTag("Smaller") && counter >= 2)
            {
                food = other.gameObject;
                Destroy(food);
                transform.localScale *= 1.1f;
                acceleration -= 0.1f;
                counter++;
                TimerText.text = string.Format("{0}", counter);
        }
            if (other.CompareTag("Small") && counter >= 3)
            {
                food = other.gameObject;
                Destroy(food);
                transform.localScale *= 1.1f;
                acceleration -= 0.1f;
                counter++;
                TimerText.text = string.Format("{0}", counter);
            }  
            if (other.CompareTag("Medium") && counter >= 4)
            {
                food = other.gameObject;
                Destroy(food);
                transform.localScale *= 1.1f;
                acceleration -= 0.1f;
                counter++;
                TimerText.text = string.Format("{0}", counter);
            }
        }

    }