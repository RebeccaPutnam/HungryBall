using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatWorld : MonoBehaviour
{
        public float speed;
        private Rigidbody2D rb;
        private GameObject tree;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        justBall ballScript = other.GetComponent<justBall>();
        if (ballScript != null && tree != null)
        {
            ballScript.Feed();
            Destroy(tree);
            tree = null; //create universal tag for objects in world that Herb will eat
            
        }

        if (other.CompareTag("tree")) //instead of "carrot," use our tag..
        {
            if (tree == null)
            {
                tree = other.gameObject;
                tree.transform.SetParent(transform);
                tree.transform.localPosition = new Vector3(0.5f, 0.0f, 0.0f);
            }
            
        }
    }
}
