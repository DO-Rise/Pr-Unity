using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        const float MinImpulse = 3f;
        const float MaxImpulse = 15f;
        float angle = Random.Range(0, 2 * Mathf.PI);

        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        float magnitude = Random.Range(MinImpulse, MaxImpulse);

        GetComponent<Rigidbody2D>().AddForce(direction* magnitude, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
