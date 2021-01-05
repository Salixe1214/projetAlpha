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
    GameObject epeeApparu;
    public GameObject epee;
    bool hitBoxActive = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hitBoxActive)
        {
            StartCoroutine(destructionEpee(epee));
        }
    }

    /// <summary>
    /// <c>coupEpee</c> est la gestion qui donne un coup d'epee en avant du joueur.
    /// </summary>
    /// <returns></returns>
    public void onUse(Vector2 position, Quaternion direction)
    {
        Debug.Log("coup epee");
        epeeApparu = Instantiate(epee, position, direction);
        hitBoxActive = true;
    }

    IEnumerator destructionEpee(GameObject item)
    {
        Debug.Log("Essaie de destruction de l'épée");
        Destroy(gameObject);
        hitBoxActive = false;
        yield return null;
    }
}


