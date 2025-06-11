using UnityEngine;

public class ActivateSphereOnCollision : MonoBehaviour
{
    // Référence au Rigidbody de la voiture (assignée dans l'éditeur Unity)
    public Rigidbody carRigidbody;

    // Vitesse du boost
    public float sphereActivationSpeed = 10f;

    // Booléen pour savoir si la sphère a été activée
    private bool sphereActivated = false;

    // Référence à la sphère attachée au mur
    public GameObject sphereObject;

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si la collision implique un objet avec le tag "Player" (ou tout autre tag que votre voiture possède)
        if (collision.gameObject.CompareTag("Player"))
        {
            // Désactive l'objet auquel le script est attaché
            gameObject.SetActive(false);

            // Active la sphère si elle est attachée à un mur
            if (sphereObject != null)
            {
                sphereObject.SetActive(true);
            }

            // Augmente la vitesse de la voiture
            carRigidbody.velocity += carRigidbody.transform.forward * sphereActivationSpeed;

            // Marque la sphère comme activée pour éviter de la réactiver
            sphereActivated = true;
        }
    }
}
