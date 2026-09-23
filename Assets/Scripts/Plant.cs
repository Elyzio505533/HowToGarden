using UnityEngine;

public class Plant : MonoBehaviour
{
    private float growthTime;
    private GameObject evilVegetablePrefab;
    private PlantingSpot plantingSpot;

    private bool isGrowing = false;

    public void StartGrowth(
        float duration,
        GameObject evilVegetable,
        PlantingSpot spot)
    {
        growthTime = duration;
        evilVegetablePrefab = evilVegetable;
        plantingSpot = spot;

        isGrowing = true;

        Invoke(nameof(SpawnEvilVegetable), growthTime);
    }

    private void SpawnEvilVegetable()
    {
        if (!isGrowing)
            return;

        if (evilVegetablePrefab == null)
        {
            Debug.LogWarning("No evil vegetable prefab assigned.");
            return;
        }

        GameObject vegetable = Instantiate(
            evilVegetablePrefab,
            transform.position,
            transform.rotation
        );

        EvilVegetable evilVegetable =
            vegetable.GetComponent<EvilVegetable>();

        if (evilVegetable != null)
        {
            evilVegetable.SetPlantingSpot(plantingSpot);
        }
        else
        {
            Debug.LogWarning(
                "The evil vegetable prefab does not contain an EvilVegetable component."
            );
        }

        Destroy(gameObject);
    }
}