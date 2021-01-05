/*
 * Ennemie1.cs
 * Code pour la gestion de la vie du joueur
 * 5 Janvier 2021
 * MelpyX
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La gestion de la <c>Vie</c> du joueur est définie ici.
/// </summary>
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

    /// <summary>
    /// <c>OnTriggerEnter2d</c> est appelé lorsqu'une collision est détecté. Elle enlève ensuite 4 points de vie au joueur et appelle une coroutine qui rend le joueur invincible pour un certain temps.
    /// </summary>
    /// <param name="CollisionEnnemi"></param>
    private void OnTriggerEnter2D(Collider2D CollisionEnnemi)
    {
        if (!estInvincible)
        {
            pointDeVie -= 4;
            StartCoroutine(invincibiliteFrame());
        }
    }

    /// <summary>
    /// <c> invincibiliteFrame</c> est une coroutine qui permet au joueur d'être invincible pour un nombre de seconde défini préalablement.
    /// </summary>
    /// <returns></returns>
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
