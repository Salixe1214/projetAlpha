using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <c>pierre</c> est la classe qui
/// parametre une pierre de lance pierre
/// </summary>
public class pierre : MonoBehaviour
{
    public int degatPierre = 2;
    public float speed = 15f;
    public int tempsAVivre = 180;

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

    /// <summary>
    /// <c>OnTriggerEnter2D</c> gere les collision de
    /// la pierre de lance pierre.
    /// </summary>
    /// <param name="collision"></param> est l'objet
    /// avec lequel la pierre entre ne collision.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se détruit en touchant un mur
        if (collision.transform.tag == "Mur")
            Destroy(gameObject);

        // Collision avec un ennemie -> le blesse
        if (collision.transform.tag == "Ennemie")
        {
            collision.transform.GetComponent<Ennemie1>().degatRecu(degatPierre);
            Destroy(gameObject);
        }
    }
}
