using UnityEngine;

public class ResourceInventory : MonoBehaviour
{
    [Header("Player Resources")]
    public int wood = 0;
    public int stone = 0;

    public void AddResource(string resourceName, int amount)
    {
        if (resourceName == "Wood")
        {
            wood += amount;
        }
        else if (resourceName == "Stone")
        {
            stone += amount;
        }

        Debug.Log(
            "Инвентарь: Древесина — " + wood +
            ", Камень — " + stone
        );
    }
}
