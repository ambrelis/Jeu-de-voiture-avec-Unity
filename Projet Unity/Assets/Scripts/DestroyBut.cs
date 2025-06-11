using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBut : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            Destroy(collision.gameObject);
        }
    }
}
