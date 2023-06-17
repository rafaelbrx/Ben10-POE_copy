using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ominitrixFloat : MonoBehaviour
{
    public float amp;
    public float freq;
    Vector3 initPos;

    void Start()
    {
        initPos = transform.position;
    }

    void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp * initPos.y, 0);   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ben10")
        {
            Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene("win");
    }
}