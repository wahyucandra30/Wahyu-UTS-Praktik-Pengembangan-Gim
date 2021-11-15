// ================================================================================================================
// UTS Praktik - DynamicColor.cs
// 
// Author: Wahyu Candra
// Date:   11/11/2021
// ================================================================================================================
using UnityEngine;

public abstract class DynamicColor : MonoBehaviour
{
    [SerializeField] protected Color primaryColor;
    [SerializeField] protected Color secondaryColor;

    public abstract void ChangeColorToPrimary();
    public abstract void ChangeColorToSecondary();
}
