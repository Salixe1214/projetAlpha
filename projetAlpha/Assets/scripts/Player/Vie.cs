using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie : MonoBehaviour
{
    public float secondesInvincibiliteApresCoup = 1;
    public int pointDeVie = 10;
    bool estInvincible = false;
    Color couleurParDefaut;

    // Start is called before the first frame update
    void Awake()
    {
        collisions.onHit += onHit;
        couleurParDefaut = GetComponent<SpriteRenderer>().color;
    }


    // Update is called once per frame
    void Update()
    {
        if (pointDeVie <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void onHit()
    {
        if (!estInvincible)
        {
            pointDeVie -= 4;
            GetComponent<SpriteRenderer>().color = new Color(.75f,.10f,.15f);
            StartCoroutine(invincibiliteFrame());
        }
    }

    IEnumerator invincibiliteFrame()
    {
        if (!estInvincible)
        {
            estInvincible = true;
            yield return new WaitForSeconds(secondesInvincibiliteApresCoup);
        }
        estInvincible = false;
        GetComponent<SpriteRenderer>().color = couleurParDefaut;
        yield return null;
    }
}
