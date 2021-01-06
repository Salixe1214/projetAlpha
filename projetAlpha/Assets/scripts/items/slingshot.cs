using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slingshot : MonoBehaviour
{
    public GameObject m_pierre;
    public int slingShotCoolDownInitial = 60;
    int slingShotCoolDown;
    bool peutUtiliserObjet = true;

    // Start is called before the first frame update
    void Start()
    {
        slingShotCoolDown = slingShotCoolDownInitial;
    }

    // Update is called once per frame
    void Update()
    {
        if (!peutUtiliserObjet)
        {
            slingShotCoolDown--;
            if (slingShotCoolDown == 0)
            {

            }
        }
    }

    public void onUse(Vector2 position, Quaternion direction)
    {
        Instantiate(m_pierre, position, Quaternion.identity).transform.rotation = direction;
    }
}
