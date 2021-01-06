using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    public Button Reprendre, Recommencer, Quitter;
    // Start is called before the first frame update
    void Start()
    {
        Reprendre.onClick.AddListener(ReprendreLaPartie);
        Recommencer.onClick.AddListener(RecommencerLaPartie);
        Quitter.onClick.AddListener(QuitterLaPartie);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Pause"))
        {
            ReprendreLaPartie();
        }
    }

    void ReprendreLaPartie()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void QuitterLaPartie()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    void RecommencerLaPartie()
    {

    }
}
