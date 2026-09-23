using UnityEngine;

public class EvilVegetable : MonoBehaviour
{
    [SerializeField] private float minLifetime = 8f;
    [SerializeField] private float maxLifetime = 12f;

    private PlantingSpot plantingSpot;

    public void SetPlantingSpot(PlantingSpot spot)
    {
        plantingSpot = spot;
    }

    private void Start()
    {
        float lifetime = Random.Range(minLifetime, maxLifetime);

        Invoke(nameof(DestroyVegetable), lifetime);
    }

    private void DestroyVegetable()
    {
        Debug.Log("Evil vegetable destroyed.");

        if (plantingSpot != null)
        {
            plantingSpot.ResetPlantingSpot();
        }
        else
        {
            Debug.LogWarning("PlantingSpot reference is missing.");
        }

        Destroy(gameObject);
    }
}