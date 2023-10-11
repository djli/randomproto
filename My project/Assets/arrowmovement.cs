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
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 50 * Time.deltaTime);
        }
    }
}
