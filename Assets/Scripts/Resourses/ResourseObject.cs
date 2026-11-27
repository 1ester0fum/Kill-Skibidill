using UnityEngine;

public class ResourceObject : MonoBehaviour
{
    [Header("Resource Settings")]
    public string resourceName = "Wood";
    public int amount = 5;

    public void Collect()
    {
        Debug.Log("Собрано: " + amount + " ед. ресурса " + resourceName);

        Destroy(gameObject);
    }
}
