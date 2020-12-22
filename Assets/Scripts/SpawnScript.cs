using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject eat;
    private Vector2 randVector;

    void Awake()
    {
        for (int i = 0; i < 100; i++)
        {
            randVector.Set(Random.Range(-25f, 25f), Random.Range(-25f, 25f));
            Instantiate(eat, randVector, Quaternion.identity);
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
