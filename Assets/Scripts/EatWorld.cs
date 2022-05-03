using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatWorld : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
       
        rb.velocity = new Vector2(inputX, inputY) * speed;
        transform.position += new Vector3(inputX, inputY, 0) * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Animal animalScript = other.GetComponent<Animal>();
        if (animalScript != null && carrot != null)
        {
            animalScript.Feed();
            Destroy(carrot);
            carrot = null; //create universal tag for objects in world that Herb will eat
            
        }

        if (other.CompareTag("Carrot")) //instead of "carrot," use our tag..
            {
                if (carrot == null)
                {
                carrot = other.gameObject;
                carrot.transform.SetParent(transform);
                carrot.transform.localPosition = new Vector3(0.5f, 0.0f, 0.0f);
                }
            }
        }
    }
}
