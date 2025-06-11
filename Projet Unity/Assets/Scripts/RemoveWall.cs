using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveWall : MonoBehaviour
{
    public GameObject Objet_a_detruire;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Remove the button
            Destroy(Objet_a_detruire); // Remove the chosen object
        }
    }
}
