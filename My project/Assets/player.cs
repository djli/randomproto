using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public GameObject arrow;
    // Start is called before the first frame update
    private GameObject myArrow = null;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = cursorPosition - bowPosition;
        transform.right = direction;
        if (Input.GetMouseButtonDown(0) && myArrow == null)
        {
            GameObject arrowIns = Instantiate(arrow, bowPosition, Quaternion.identity);
            arrowIns.transform.right = direction;
            arrowIns.GetComponent<Rigidbody2D>().AddForce(direction * 100);
        }
    }
}
