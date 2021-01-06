using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Epee : MonoBehaviour
{
    public int tempsAVivre = 2;
    bool asUtiliseEpee = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (tempsAVivre == 0)
            Destroy(gameObject);
        
        tempsAVivre--;
        
    }

    public void onUse(Vector2 position, Quaternion direction)
    {
        GameObject epeeApparu = Instantiate(gameObject, position, direction);
        print(transform.position);
        epeeApparu.transform.position += direction*transform.up/2;
        asUtiliseEpee = true;
    }
}
