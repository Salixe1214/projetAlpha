using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie : MonoBehaviour
{
    public float secondesInvincibiliteApresCoup = 2;
    public int pointDeVie = 10;
    bool estInvincible = false;

    // Start is called before the first frame update
    void Awake()
    {
        collisions.onHit += onHit;
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
        yield return null;
    }
}
