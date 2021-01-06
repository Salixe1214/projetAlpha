using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pierre : MonoBehaviour
{
    int tempsAVivre = 180;
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempsAVivre--;
        if (tempsAVivre <= 0)
            Destroy(gameObject);
         
        transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Coll");
        if (collision.transform.tag == "Mur")
            Destroy(gameObject);
        
    }
}
