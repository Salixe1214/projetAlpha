using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gestionItems : MonoBehaviour
{
    enum items { epee, map, boomerang, radar, lancePierre, rien };

    public GameObject epee;
    public GameObject lancePierre;
    items itemActif1, itemActif2;
    
    public Image itemSlot1;
    public Image itemSlot2;

    public Sprite[] itemsSprites;

    // Start is called before the first frame update
    void Start()
    {
        itemActif1 = items.epee;
        itemSlot1.sprite = itemsSprites[(int)itemActif1];

        itemActif2 = items.lancePierre;
        itemSlot2.sprite = itemsSprites[(int)itemActif2];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Item1"))
        {
            useItem(itemActif1);
        }

        if (Input.GetButtonDown("Item2"))
        {
            useItem(itemActif2);
        }

        if (Input.GetButtonDown("Interaction"))
        {
            if (itemActif1 == items.rien)
                itemActif1 = items.epee;
            else
                itemActif1++;
            if (itemActif2 == items.rien)
                itemActif2 = items.epee;
            else
                itemActif2++;
        }

        itemSlot1.sprite = itemsSprites[(int)itemActif1];
        itemSlot2.sprite = itemsSprites[(int)itemActif2];
    }

    void useItem(items item)
    {
        switch (item)
        {
            case items.epee:
                StartCoroutine(useEpee());
                break;
            case items.boomerang:
                StartCoroutine(useBoomerang());
                break;
            case items.lancePierre:
                StartCoroutine(useSlingShot());
                break;
            case items.map:
                StartCoroutine(useMap());
                break;
            case items.radar:
                StartCoroutine(useRadar());
                break;
            default:
                break;
        }
    }

    IEnumerator useSlingShot()
    {
        Debug.Log("J'utilise le lance pierre!");
        lancePierre.GetComponent<slingshot>().onUse(transform.position, transform.rotation);
        yield return null;
    }

    IEnumerator useEpee()
    {
        Debug.Log("J'utilise l'épée!");
        epee.GetComponent<Epee>().onUse(transform.position,transform.rotation);
        yield return null;
    }

    IEnumerator useBoomerang()
    {
        Debug.Log("J'utilise le boomerang!");
        yield return null;
    }

    IEnumerator useMap()
    {
        Debug.Log("J'utilise la map!");
        yield return null;
    }

    IEnumerator useRadar()
    {
        Debug.Log("J'utilise le radar!");
        yield return null;
    }
}
