using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI rockText;

    // Start is called before the first frame update
    void Start()
    {
        rockText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateRockText(playerInventory playerInventory)
    {
        rockText.text = playerInventory.NumberOfRocks.ToString();
    }


}
