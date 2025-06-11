using UnityEngine;

public class SphereController : MonoBehaviour
{
    // Méthode appelée lorsque quelque chose entre en collision avec la sphère
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("voiture")) // Vérifie si la voiture a activé la sphère
        {
            gameObject.SetActive(false); // Désactive la sphère
        }
    }
}