/*
 * mouvements.cs
 * Code pour les deplacements du joueur
 * 4 decembre 2021
 * Salixe
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// <c>mouvements</c> definie et gere les mouvements du joueur.
/// </summary>
public class mouvements : MonoBehaviour
{
    public float speed = 7f;

    float angle;
    Vector2 velocity;

    new Rigidbody2D rigidbody;
    Camera cam;
    Quaternion camRot;

    /// <summary>
    /// <c>Start</c> est appele a la premiere
    /// update de frame.
    /// </summary>
    void Start()
    {
        // Recuperation du rigidBody2D
        rigidbody = GetComponent<Rigidbody2D>();

        // Recuperation de la camera
        cam = gameObject.GetComponentInChildren<Camera>();
        camRot = cam.transform.rotation;

        // Retrait de la gravite
        rigidbody.mass = 0f;
        rigidbody.gravityScale = 0f;
    }

    /// <summary>
    /// <c>Update</c> est execute a chaque frame.
    /// </summary>
    void Update()
    {
        // Ça fait bouger quand on clic
        mouvSansCamRot();
    }

    /// <summary>
    /// <c>FixedUpdate</c> est execute a des
    /// temps fixes.
    /// </summary>
    private void FixedUpdate()
    {
        // Deplacement du personnage devant lui.
        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
    }
    
    /// <summary>
    /// <c>mouvSansCamRot</c> gere les 
    /// deplacements pour une cam sans
    /// rotation.
    /// </summary>
    void mouvSansCamRot()
    {
        // Direction du joueur definie par les
        // entre verticales et horizontales.
        Vector2 inputDirection = new Vector2(Input.GetAxisRaw("Horizontal"),
                                   Input.GetAxisRaw("Vertical")).normalized;

        // On ne change l'orientation que si le
        // joueur entre activement une 
        // orientation.
        if (inputDirection.magnitude != 0)
        {
            angle = Mathf.Atan2(inputDirection.x, inputDirection.y) * Mathf.Rad2Deg;
            transform.eulerAngles = Vector3.back * angle;
        }

        // Vitesse de deplacement
        velocity = transform.up * speed * inputDirection.magnitude;

        cam.transform.rotation = camRot;
    }

}
