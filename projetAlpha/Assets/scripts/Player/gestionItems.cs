using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gestionItems : MonoBehaviour
{
    enum items { epee, boomerang, lancePierre, map, radar, rien };
    GameObject[] inventaire = new GameObject[6];

    public GameObject epee;
    items itemActif1, itemActif2;
    public bool itemEnable1 = true;
    public bool itemEnable2 = true;

    public Image itemSlot1;
    public Image itemSlot2;

    public Sprite[] itemsSprites;

    // GameObject coffre = null;

    // Start is called before the first frame update
    void Start()
    {
        inventaire[(int) items.epee] = epee;
        itemActif1 = items.epee;
        itemSlot1.sprite = itemsSprites[(int)itemActif1];

        itemActif2 = items.rien;
        itemSlot2.sprite = itemsSprites[(int)itemActif2];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Item1") && itemEnable1 && inventaire[(int)itemActif1] != null)
        {
            useItem(itemActif1);

            boomrang.mortBoomrang += enableItem1;
            Epee.mortEpee += enableItem1;
            pierre.mortPierre += enableItem1;

            itemEnable1 = false;
        }

        if (Input.GetButtonDown("Item2") && itemEnable2 && inventaire[(int)itemActif2] != null)
        {
            useItem(itemActif2);

            boomrang.mortBoomrang += enableItem2;
            Epee.mortEpee += enableItem2;
            pierre.mortPierre += enableItem2;

            itemEnable2 = false;
        }

        if (Input.GetButtonDown("Interaction"))
        {
            if (itemActif1 == items.rien)
                itemActif1 = items.epee;
            else
            {
                itemActif1++;
                if (inventaire[(int)itemActif1] == null)
                    itemActif1 = items.rien;
            }
            if (itemActif2 == items.rien)
                itemActif2 = items.epee;
            else
            {
                itemActif2++;
                if (inventaire[(int)itemActif2] == null)
                    itemActif2 = items.rien;
            }
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
        inventaire[(int)items.lancePierre].GetComponent<slingshot>().onUse(transform.position, transform.rotation);
        yield return null;
    }

    IEnumerator useEpee()
    {
        inventaire[(int)items.epee].GetComponent<Epee>().onUse(transform.position,transform.rotation);
        yield return null;
    }

    IEnumerator useBoomerang()
    {
        Vector3 postionLance = transform.position + transform.up * 1;
        GameObject boomrangLance = Instantiate(inventaire[(int)items.boomerang], postionLance, transform.rotation);
        boomrangLance.GetComponent<boomrang>().lanceur = gameObject;
        boomrangLance.GetComponent<boomrang>().angle = transform.up;
        yield return null;
    }

    IEnumerator useMap()
    {
        Debug.Log("J'utilise la map!");
        enableItem1();
        enableItem2();
        yield return null;
    }

    IEnumerator useRadar()
    {
        Debug.Log("J'utilise le radar!");
        enableItem1();
        enableItem2();
        yield return null;
    }

    public void enableItem1()
    {
        itemEnable1 = true;

        boomrang.mortBoomrang -= enableItem1;
        Epee.mortEpee -= enableItem1;
        pierre.mortPierre -= enableItem1;
    }

    public void enableItem2()
    {
        itemEnable2 = true;

        boomrang.mortBoomrang -= enableItem2;
        Epee.mortEpee -= enableItem2;
        pierre.mortPierre -= enableItem2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("LOL");
        if (collision.collider.tag == "Coffre")
        {
            GameObject objetCoffre = collision.gameObject.GetComponent<coffre>().itemContenu;
            items item;

            switch (objetCoffre.tag)
            {
                case "Boomrang":
                    Debug.Log("boomrang");
                    item = items.boomerang;
                    break;
                case "LancePierre":
                    Debug.Log("boomrang");
                    item = items.lancePierre;
                    break;
                case "Map":
                    item = items.map;
                    break;
                case "Radar":
                    item = items.radar;
                    break;
                default:
                    item = items.rien;
                    break;
            }

            if(item != items.rien)
            {
                inventaire[(int)item] = objetCoffre;
            }

            Destroy(collision.gameObject);
        }
    }
}
