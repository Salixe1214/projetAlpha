using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epee : MonoBehaviour
{
    public int degatEpee = 5;
    public int tempsAVivre = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tempsAVivre == 0)
            Destroy(gameObject);
        tempsAVivre--;
    }

    public void onUse(Vector2 position, Quaternion direction)
    {
        GameObject epeeApparu = Instantiate(gameObject, position, direction);
        epeeApparu.transform.position += direction*transform.up;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.transform.tag);
        if (collision.transform.tag == "Ennemie")
            collision.transform.GetComponent<Ennemie1>().degatRecu(degatEpee);
    }
}
