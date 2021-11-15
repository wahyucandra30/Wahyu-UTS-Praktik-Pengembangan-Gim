// ================================================================================================================
// UTS Praktik - DynamicTextColor.cs
// 
// Author: Wahyu Candra
// Date:   11/11/2021
// ================================================================================================================
using UnityEngine;
using TMPro;

public class DynamicTextColor : DynamicColor
{
    private TextMeshProUGUI text;


    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public override void ChangeColorToPrimary()
    {
        ChangeTextColor(primaryColor);
    }
    public override void ChangeColorToSecondary()
    {
        ChangeTextColor(secondaryColor);
    }
    private void ChangeTextColor(Color color)
    {
        text.color = color;
    }
}
