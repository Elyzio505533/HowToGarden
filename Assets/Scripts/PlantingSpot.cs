using UnityEngine;

public class PlantingSpot : MonoBehaviour
{
    [SerializeField] private GameObject seedPrefab;
    [SerializeField] private Transform plantingPoint;
    [SerializeField] private GameObject plantingPrompt;
    private PlayerInteraction playerInteraction;
    private bool isPlanted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInteraction = other.GetComponent<PlayerInteraction>();

            if (playerInteraction != null)
            {
                playerInteraction.SetPlantingSpot(this);

                if (!isPlanted)
                {
                    playerInteraction.ShowPlantingPrompt();
                }
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
        if (isPlanted)
        {
            return;
        }

        if (seedPrefab == null)
        {
            Debug.LogWarning("No seed prefab assigned to this planting spot.");
        }

        if (plantingPoint == null)
        {
            Debug.LogWarning("No planting point assigned to this planting spot.");
        }

        GameObject seedObject = Instantiate(seedPrefab, transform.position, transform.rotation);

        Seed seed = seedObject.GetComponent<Seed>();

        if (seed != null)
        {
            seed.SetPlantingSpot(this);
        }
        else
        {
            Debug.LogWarning("The seed prefab does not contain a Seed component.");
        }

        isPlanted = true;

        if (playerInteraction != null)
        {
            playerInteraction.HidePlantingPrompt();
        }

        Debug.Log("Seed planted.");
    }

    public void ResetPlantingSpot()
    {
        isPlanted = false;

        if (playerInteraction != null)
        {
            playerInteraction.ShowPlantingPrompt();
        }

        Debug.Log("Planting spot is available again.");
    }

    private void UpdatePlantingPrompt()
    {
        if (plantingPrompt == null)
        {
            return;
        }

        if (isPlanted)
        {
            plantingPrompt.SetActive(false);
        }
        else if (playerInteraction != null)
        {
            plantingPrompt.SetActive(true);
        }
    }
}