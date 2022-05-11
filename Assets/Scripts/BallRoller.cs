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
        }
        if (other.CompareTag("Smaller") && counter >= 5)
        {
            EatFood(other);
        }
        if (other.CompareTag("Small") && counter >= 10)
        {
            EatFood(other);
        }
        if (other.CompareTag("Medium") && counter >= 15)
        {
            EatFood(other);
        }
        if (other.CompareTag("Big") && counter >= 20)
        {
            EatFood(other);
        }
        if (other.CompareTag("Bigger") && counter >= 25)
        {
            EatFood(other);
        }
        if (other.CompareTag("Biggest") && counter >= 30)
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
        TimerText.text = string.Format("{0} / 40", counter);
        if (counter == 5 || counter == 10 || counter == 15 || counter == 20 || counter == 25 || counter ==30)
        {
            transform.localScale *= 1.1f;
            acceleration -= 0.1f;
        }
    }

    public int FinalCount()
    {
        int finalCount = counter;
        return finalCount;
    }

}