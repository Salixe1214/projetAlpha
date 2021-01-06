/*
 * Ennemie1.cs
 * Code pour les deplacements et les statistiques de l'ennemie1
 * 4 Janvier 2021
 * MelpyX
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// La classe<c> Ennemie1 </c> defini les comportement d'un énemi et ses statistiques.
/// </summary>
public class Ennemie1 : MonoBehaviour
{
    public int vieEnnemie1 = 5;
    public Transform chemin;
    public float vitesse = 15f;
    public float tempsAttente = 1.5f;

    private int itProchainPoint = 1;
    // Start is called before the first frame update
    void Start()
    {
        Vector2[] pointArret = new Vector2[chemin.childCount];
        for (int i = 0; i < chemin.childCount; i++)
        {
            pointArret[i] = chemin.GetChild(i).position;
            pointArret[i] = new Vector2(pointArret[i].x, pointArret[i].y);
        }
        transform.position = chemin.GetChild(0).position;
        StartCoroutine(patrouilleEnnemie1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void degatRecu(int dommage)
    {
        vieEnnemie1 -= dommage;
        if (vieEnnemie1 <= 0)
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// <c>patrouilleEnnemie1</c> defini comment l'ennemie1 se déplace.
    /// </summary>
    /// <returns></returns>
    IEnumerator patrouilleEnnemie1()
    {
        while(true)
        {
            transform.position = Vector2.MoveTowards(transform.position, chemin.GetChild(itProchainPoint).position, vitesse * Time.deltaTime);
            if(transform.position == chemin.GetChild(itProchainPoint).position)
            {
                itProchainPoint = (itProchainPoint + 1) % chemin.childCount;
                    yield return new WaitForSeconds(tempsAttente);
            }
            yield return null;
        }
    }
    /// <summary>
    /// Dessine le chemin qu'empruntera l'ennemie1 (Debug seulement).
    /// </summary>
    private void OnDrawGizmos()
    {
        Vector2 startPosition = chemin.GetChild(0).position;
        Vector2 previousPosition = startPosition;

        foreach (Transform points in chemin)
        {
            Gizmos.DrawSphere(points.position, .3f);
            Gizmos.DrawLine(previousPosition, points.position);
            previousPosition = points.position;
        }
        Gizmos.DrawLine(previousPosition, startPosition);

        Gizmos.color = Color.red;

    }
}
