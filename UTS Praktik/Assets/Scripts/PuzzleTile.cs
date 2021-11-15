// ================================================================================================================
// UTS Praktik - PuzzleTile.cs
// 
// Author: Wahyu Candra
// Date:   12/11/2021
// ================================================================================================================
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzleTile : MonoBehaviour
{
    [SerializeField] private int signature;

    public int GetSignature() => signature;
    public void Disable() => gameObject.SetActive(false);
    public void Deselect(BaseEventData eventData)
    { 
        GetComponent<Button>().OnDeselect(eventData);
        GetComponent<EventTrigger>().OnDeselect(eventData);
    }
}
