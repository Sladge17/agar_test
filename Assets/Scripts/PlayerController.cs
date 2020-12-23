using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Vector2 vec2mousepos;
    public float playermass;
    private float playerspeed;
    private Vector3 vec3playerscale;
    public Camera camera;

    private Vector2 vec2eatpos;
    private float factoreatscale;
    private Vector3 vec3eatscale;
    
    // Start is called before the first frame update
    void Start()
    {
        playermass = 0;
        playerspeed = 4;
        vec3playerscale.Set(1, 1, 1);
        camera.orthographicSize = 4;
    }

    // Update is called once per frame
    void Update()
    {
        vec2mousepos = Input.mousePosition;
        vec2mousepos = Camera.main.ScreenToWorldPoint(vec2mousepos);
        vec2mousepos -= (Vector2)transform.position;
        transform.Translate(vec2mousepos * Time.deltaTime * playerspeed);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Eat")
        {
            if (collider.transform.localScale[0] < vec3playerscale[0])
            {
                playermass += 10;
                playerspeed *= 0.95f;
                vec3playerscale.Set((playermass / 200 + 0.95f), (playermass / 200 + 0.95f), 1);
                transform.localScale = vec3playerscale;
                vec2eatpos.Set(Random.Range(-25f, 25f), Random.Range(-25f, 25f));
                collider.gameObject.transform.position = vec2eatpos;
                factoreatscale = Random.Range(0.2f, 4f);
                vec3eatscale.Set(factoreatscale, factoreatscale, 1);
                collider.gameObject.transform.localScale = vec3eatscale;
                if (playermass % 100 == 0)
                    camera.orthographicSize *= 1.02f;
                return;
            }
            SceneManager.LoadScene("menu");
        }
    }
}
