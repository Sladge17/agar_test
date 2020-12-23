using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject eat;
    private Vector2 vec2pos;
    private float factorscale;
    private Vector3 vec3scale;

    void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            vec2pos.Set(Random.Range(-25f, 25f), Random.Range(-25f, 25f));
            Instantiate(eat, vec2pos, Quaternion.identity);
            factorscale = Random.Range(0.2f, 4f);
            vec3scale.Set(factorscale, factorscale, 1);
            eat.transform.localScale = vec3scale;
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
