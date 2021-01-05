using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie : MonoBehaviour
{
    public float secondesInvincibiliteApresCoup = 2;
    public int pointDeVie = 10;
    bool estInvincible = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (pointDeVie <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D CollisionEnnemi)
    {
        if (!estInvincible)
        {
            pointDeVie -= 4;
            StartCoroutine(invincibiliteFrame());
        }
    }

    IEnumerator invincibiliteFrame()
    {
        if (!estInvincible)
        {
            estInvincible = true;
            Debug.Log("est invincible");
            yield return new WaitForSeconds(secondesInvincibiliteApresCoup);
        }
        estInvincible = false;
        Debug.Log("est pas invincible");
        yield return null;
    }
}
