/*
 * Ennemie1.cs
 * Code pour le comportement de l'item "epee"
 * 5 Janvier 2021
 * MelpyX
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epee : MonoBehaviour
{
    bool itemEstUtilisableDansLaSloth1 = true;
    bool itemEstUtilisableDansLaSloth2 = true;
    // Start is called before the first frame update
    void Start()
    {
        if (itemEstUtilisableDansLaSloth1 || itemEstUtilisableDansLaSloth2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(coupEpee());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (itemEstUtilisableDansLaSloth1 || itemEstUtilisableDansLaSloth2)
        {
            if (true)
            {
                Debug.Log("coup epee");
                StartCoroutine(coupEpee());
            }
        }
    }

    /// <summary>
    /// <c>coupEpee</c> est la gestion qui donne un coup d'epee en avant du joueur.
    /// </summary>
    /// <returns></returns>
    IEnumerator coupEpee()
    {
        Debug.Log("coup epee");
        Instantiate(hitboxEpee, transform.position, transform.rotation);
        yield return null;
    }
}
