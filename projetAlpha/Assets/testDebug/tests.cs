using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tests : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log("mouse1");
        }
        if (Input.GetAxisRaw("Item1") != 0)
        {
            Debug.Log("Item 1");
        }
        if (Input.GetAxisRaw("Item2") != 0)
        {
            Debug.Log("Item 2");
        }
    }
}
