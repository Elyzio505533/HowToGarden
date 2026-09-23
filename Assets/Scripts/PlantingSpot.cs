using UnityEngine;

public class PlantingSpot : MonoBehaviour
{
    private PlayerInteraction playerInteraction;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInteraction = other.GetComponent<PlayerInteraction>();
            if (playerInteraction != null)
            {
                playerInteraction.SetPlantingSpot(this);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerInteraction != null)
            {
                playerInteraction.ClearPlantingSpot(this);
                playerInteraction = null;
            }
        }
    }

    public void Interact()
    {
        Debug.Log("Planting");
    }
}