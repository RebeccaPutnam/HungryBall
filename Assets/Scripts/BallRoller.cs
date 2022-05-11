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

    public AudioClip eatsound;

    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
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
                EatFood(other);

                if (counter == 5)
                {
                    GrowPlayer();
                } 
            }

            if (other.CompareTag("Smaller") && counter >= 5)
            {
                EatFood(other);
                if (counter == 10)
                {
                    GrowPlayer();
                }
            }
            if (other.CompareTag("Small") && counter >= 10)
            {
                EatFood(other);
                if (counter == 15)
                {
                    GrowPlayer();
                }
            }  
            if (other.CompareTag("Medium") && counter >= 15)
            {
                EatFood(other);
                if (counter == 20)
                {
                    GrowPlayer();
                }
            }
            if (other.CompareTag("Big") && counter >= 20)
            {
                EatFood(other);
                if (counter == 25)
                {
                    GrowPlayer();
                }
            }
            if (other.CompareTag("Bigger") && counter >= 25)
            {
                EatFood(other);
                if (counter == 30)
                {
                    GrowPlayer();
                }
            }
            if (other.CompareTag("Medium") && counter >= 30)
            {
                EatFood(other);
            }
    }

    void EatFood(Collider other)
    {
        food = other.gameObject;
        Destroy(food);
        audioSource.PlayOneShot(eatsound);
        counter++;
        TimerText.text = string.Format("{0}", counter);
    }

    void GrowPlayer()
    {
        transform.localScale *= 1.1f;
        acceleration -= 0.1f;
    }

    }