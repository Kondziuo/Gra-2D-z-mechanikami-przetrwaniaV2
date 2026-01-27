using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CraftingButtonUI : MonoBehaviour
{
    public Image buttonBg;
    public TextMeshProUGUI textColor;
    public int craftingIndex; 


    public void ColorSwitch(bool canCraft)
    {
        if (canCraft)
        {
            buttonBg.color = new Color(1f, 1f, 1f, 0.5f);
            textColor.color = Color.black;
        }
        if (!canCraft)
        {
            buttonBg.color = new Color(0f, 0f, 0f, 0.9f);
            textColor.color = Color.white;
        }



    }
}
