using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Move : MonoBehaviour
{
    AudioSource destroyed;
    AudioSource lose;
    AudioSource background;
    public float speed;
    public Boundary boundary;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        destroyed = audios[0];
        lose = audios[1];
        background = audios[2];
        background.PlayDelayed(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().velocity = movement * speed;
        GetComponent<Rigidbody>().position = new Vector3
       (
           Mathf.Clamp(GetComponent<Rigidbody>().position.x, boundary.xMin, boundary.xMax),
           0.0f,
           Mathf.Clamp(GetComponent<Rigidbody>().position.z, boundary.zMin, boundary.zMax)
       );
    }
   
    void OnCollisionEnter()
    {
        if(gameObject.name == "Sprite")
        {
            destroyed.Play();
            Time.timeScale = 0;
            lose.PlayDelayed(1);
            background.Stop();
        }
        Destroy(gameObject, 1.5f);
    }
}
