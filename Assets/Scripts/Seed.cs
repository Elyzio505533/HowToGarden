using UnityEngine;

public class Seed : MonoBehaviour
{
    [Header("Seed Growth")]
    [SerializeField] private float minGrowthTime = 8f;
    [SerializeField] private float maxGrowthTime = 15f;

    [Header("Plant Growth")]
    [SerializeField] private float minPlantGrowthTime = 15f;
    [SerializeField] private float maxPlantGrowthTime = 30f;
    [SerializeField] private GameObject plantPrefab;

    [Header("Evil Vegetable")]
    [SerializeField] private GameObject evilVegetablePrefab;

    private PlantingSpot plantingSpot;
    private bool hasGrown = false;

    public void SetPlantingSpot(PlantingSpot spot)
    {
        plantingSpot = spot;
    }

    private void Start()
    {
        float growthTime = Random.Range(minGrowthTime, maxGrowthTime);

        Invoke(nameof(Grow), growthTime);
    }

    private void Grow()
    {
        if (hasGrown)
            return;

        hasGrown = true;

        Debug.Log("Seed has finished growing.");

        SpawnPlant();
    }

    private void SpawnPlant()
    {
        if (plantPrefab == null)
        {
            Debug.LogWarning("No plant prefab assigned.");
            return;
        }

        GameObject plant = Instantiate(
            plantPrefab,
            transform.position,
            transform.rotation
        );

        Plant plantScript = plant.GetComponent<Plant>();

        if (plantScript != null)
        {
            float plantGrowthTime = Random.Range(
                minPlantGrowthTime,
                maxPlantGrowthTime
            );

            plantScript.StartGrowth(
                plantGrowthTime,
                evilVegetablePrefab,
                plantingSpot
            );
        }
        else
        {
            Debug.LogWarning(
                "The plant prefab does not contain a Plant component."
            );
        }

        Destroy(gameObject);
    }
}