using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gemFloat : MonoBehaviour
{
    public float amp;
    public float freq;
    Vector3 initPos; 
    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(initPos.x, Mathf.Sin(Time.time * freq) * amp * initPos.y, 0);   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "ben10")
        {
            CompleteLevel();
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene("SecondScene");
    }
}