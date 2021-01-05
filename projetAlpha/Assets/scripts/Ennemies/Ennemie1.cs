using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemie1 : MonoBehaviour
{
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
