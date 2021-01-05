using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingshot : MonoBehaviour
{
    public GameObject m_pierre;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onUse(Vector2 position, Quaternion direction)
    {
        Instantiate(m_pierre, position, Quaternion.identity).transform.rotation = direction;
    }
}
