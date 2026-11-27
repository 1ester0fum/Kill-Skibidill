using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [Header("Collection Settings")]
    public float interactionRadius = 1.5f;

    private ResourceInventory inventory;

    void Awake()
    {
        inventory = GetComponent<ResourceInventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryCollect();
        }
    }

    void TryCollect()
    {
        Collider2D[] nearbyObjects =
            Physics2D.OverlapCircleAll(
                transform.position,
                interactionRadius
            );

        foreach (Collider2D nearbyObject in nearbyObjects)
        {
            ResourceObject resource =
                nearbyObject.GetComponent<ResourceObject>();

            if (resource != null && inventory != null)
            {
                inventory.AddResource(
                    resource.resourceName,
                    resource.amount
                );

                resource.Collect();
                return;
            }
        }

        Debug.Log("Рядом нет ресурсов для сбора");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(
            transform.position,
            interactionRadius
        );
    }
}
