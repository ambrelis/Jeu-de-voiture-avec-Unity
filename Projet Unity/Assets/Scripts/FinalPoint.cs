using UnityEngine;

public class FinalPoint : MonoBehaviour
{
    [SerializeField] GameObject winMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            winMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
