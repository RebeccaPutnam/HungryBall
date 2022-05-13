using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallRoller : MonoBehaviour
{

    public float acceleration = 10;
    private GameObject food;
    private Rigidbody rb;
    private int counter;
    private int finalCount;
    private int highScore = 0;

    public Transform ballCamera;

    public Text FoodCount;

    public AudioClip eatsound;

    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        
        highScore = PlayerPrefs.GetInt("HighScore");

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
        if (other.CompareTag("Medium") && counter >= 18)
        {
            EatFood(other);
        }
        if (other.CompareTag("Big") && counter >= 25)
        {
            EatFood(other);
        }
        if (other.CompareTag("Bigger") && counter >= 35)
        {
            EatFood(other);
        }
        if (other.CompareTag("Biggest") && counter >= 48)
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
        FoodCount.text = string.Format("{0} / 65", counter);
        if (counter == 5 || counter == 10 || counter == 15 || counter == 20 || counter == 25 || counter ==30)
        {
            transform.localScale *= 1.2f;
            acceleration -= 0.1f;
        }
    }

    public void FinalCount()
    {
        finalCount = counter;
        PlayerPrefs.SetInt("Score", finalCount);
    }

    public void UpdateHighScore()
    {
        if (SceneManager.GetActiveScene().name == "WinterLevel")
        {
            highScore = PlayerPrefs.GetInt("WinterHighScore");
            if (counter >= highScore)
            {
                highScore = counter;
                PlayerPrefs.SetInt("WinterHighScore", highScore);
            }
        }
        if (SceneManager.GetActiveScene().name == "SummerLevel")
        {
            highScore = PlayerPrefs.GetInt("SummerHighScore");
            if (counter >= highScore)
            {
                highScore = counter;
                PlayerPrefs.SetInt("SummerHighScore", highScore);
            }
        }
        if (SceneManager.GetActiveScene().name == "FallLevel")
        {
            highScore = PlayerPrefs.GetInt("FallHighScore");
            if (counter >= highScore)
            {
                highScore = counter;
                PlayerPrefs.SetInt("FallHighScore", highScore);
            }
        }
    }

}