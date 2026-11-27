using UnityEngine;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    public ResourceInventory inventory;
    public TMP_Text resourceText;

    void Update()
    {
        resourceText.text =
            "Дерево: " + inventory.wood +
            "\nКамень: " + inventory.stone;
    }
}
