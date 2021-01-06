using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collisions : MonoBehaviour
{
    public static event System.Action onHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            SceneManager.LoadScene(0);
        }
        if(collision.tag == "Ennemie" && onHit != null)
        {
            onHit();
        }
    }
}
