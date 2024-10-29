using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    private float lastMouseX;

    // Start is called before the first frame update
    void Start()
    {
        lastMouseX = Input.mousePosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;

        Vector2 direction = Vector2.zero;

        if (Input.mousePosition.x > lastMouseX)
            direction = Vector2.right * speed;
        else if (Input.mousePosition.x < lastMouseX)
            direction = Vector2.left * speed;

        lastMouseX = Input.mouseScrollDelta.x;

        position.x += direction.x * Time.deltaTime;
        transform.position = position;
    }
}
