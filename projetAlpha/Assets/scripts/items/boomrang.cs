using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomrang : MonoBehaviour
{
    public float rotParSeconde = 3;
    public float tempsDeLancer = 5;
    float tempsImmateriel;

    public float speed = 10;
    public int degatBoomerang = 1;
    public Vector3 angle;
    public GameObject lanceur;

    Vector3 directionRetour;

    // Start is called before the first frame update
    void Awake()
    {
        tempsImmateriel = tempsDeLancer - .1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * -360 * rotParSeconde * Time.deltaTime);
        if (tempsDeLancer >= 0)
        {
            tempsDeLancer -= Time.deltaTime;
            transform.position += angle * speed * Time.deltaTime;
        }
        else
        {
            GetComponent<Collider2D>().isTrigger = true;
            
            directionRetour = (lanceur.transform.position - transform.position).normalized;
            transform.position += (directionRetour * Time.deltaTime * speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            Destroy(gameObject);
        
        if (collision.transform.tag == "Ennemie")
            collision.transform.GetComponent<Ennemie1>().degatRecu(degatBoomerang);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && tempsDeLancer <= tempsImmateriel)
            Destroy(gameObject);

        if (collision.collider.tag == "Mur")
        {
            angle = collision.contacts[0].normal;
        }

        if (collision.transform.tag == "Ennemie")
            collision.transform.GetComponent<Ennemie1>().degatRecu(degatBoomerang);
    }
}
