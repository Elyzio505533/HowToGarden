using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    private PlantingSpot currentPlantingSpot;
    [SerializeField] private GameObject plantingPrompt;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }

        if (currentPlantingSpot != null)
        {
            currentPlantingSpot.Interact();
        }
    }

    public void SetPlantingSpot(PlantingSpot plantingSpot)
    {
        currentPlantingSpot = plantingSpot;
    }

    public void ClearPlantingSpot(PlantingSpot plantingSpot)
    {
        if (currentPlantingSpot == plantingSpot)
        {
            currentPlantingSpot = null;
            HidePlantingPrompt();
        }
    }

    public void HidePlantingPrompt()
    {
        plantingPrompt.SetActive(false);
    }

    public void ShowPlantingPrompt()
    {
        plantingPrompt.SetActive(true);
    }
}
