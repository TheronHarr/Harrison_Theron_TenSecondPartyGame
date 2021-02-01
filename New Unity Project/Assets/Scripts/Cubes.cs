using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubes : MonoBehaviour
{
    public float delay = 0.1f;
    public GameObject Cube;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn",delay,delay);
    }

    // Update is called once per frame
    void Spawn()
    {
        Instantiate(Cube, new Vector3(UnityEngine.Random.Range(-6, 6), 10, 0),Quaternion.identity);
    }
}
