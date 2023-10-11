using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowmovement : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(rb.velocity, transform.right);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 70 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("walls"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("yellow"))
        {
            //add 50 points
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("red"))
        {
            //add 25 points
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("blue"))
        {
            //add 10 points
            Destroy(this.gameObject);
        }
    }
}
