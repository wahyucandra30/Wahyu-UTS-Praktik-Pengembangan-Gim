// ================================================================================================================
// UTS Praktik - DynamicImageColor.cs
// 
// Author: Wahyu Candra
// Date:   11/11/2021
// ================================================================================================================
using UnityEngine;
using UnityEngine.UI;

public class DynamicImageColor : DynamicColor
{
    private Image img;
    

    private void Awake()
    {
        img = GetComponent<Image>();
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
        img.color = color;
    }
}
