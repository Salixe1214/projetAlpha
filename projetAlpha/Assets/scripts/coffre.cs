using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coffre : MonoBehaviour
{
    public GameObject itemContenu;

    // Start is called before the first frame update
    void Start()
    {
        if(itemContenu != null)
            GetComponent<SpriteRenderer>().sprite = itemContenu.GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
