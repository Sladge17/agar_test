using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 mousePosition;
    private Vector2 randVec;
    public float mass;
    private float speed;
    private Vector3 vecScale;
    // Start is called before the first frame update
    void Start()
    {
        mass = 10;
        speed = 4;
        vecScale.Set(1, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition -= (Vector2)transform.position;
        transform.Translate(mousePosition * Time.deltaTime * speed);
        transform.localScale = vecScale;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Eat")
        {
            mass += 10;
            speed *= 0.95f;
            vecScale.Set((mass / 200 + 0.95f), (mass / 200 + 0.95f), 1);
            randVec.Set(Random.Range(-25f, 25f), Random.Range(-25f, 25f));
            collider.gameObject.transform.position = randVec;
        }
    }
}
