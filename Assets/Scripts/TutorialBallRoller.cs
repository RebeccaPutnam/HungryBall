using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialBallRoller : MonoBehaviour
{

    public float acceleration = 10;
    private GameObject food;
    private Rigidbody rb;
    private int counter;

    public Transform ballCamera;

    public Text FoodCount;

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

        if (other.CompareTag("Medium") && counter >= 20)
        {
            EatFood(other);
        }

        if (other.CompareTag("Big") && counter >= 30)
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
        FoodCount.text = string.Format("{0} / 40", counter);
        if (counter == 5 || counter == 20 || counter == 30)
        {
            transform.localScale *= 1.5f;
            acceleration -= 0.1f;
        }
        if (counter == 40)
        {
            SceneManager.LoadScene(7);
        }

    }
}