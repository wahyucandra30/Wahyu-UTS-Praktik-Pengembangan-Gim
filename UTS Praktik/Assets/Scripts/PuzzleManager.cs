// ================================================================================================================
// UTS Praktik - PuzzleManager.cs
// 
// Author: Wahyu Candra
// Date:   12/11/2021
// ================================================================================================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleManager : MonoBehaviour
{
    [Range(0f, 2f)]
    [SerializeField] private float shuffleSpeed;
    [SerializeField] private AudioClip matchSound;
    [SerializeField] private AudioClip wrongSound;
    private const int MAX_SELECTION_COUNT = 2;
    private List<PuzzleTile> tileList;
    private List<PuzzleTile> selectedTileList;
    private List<Vector2> posList;
    private List<Vector2> availablePosList;
    private AudioManager audioManager;
    private EventSystem eventSystem;

    private void Awake()
    {
        tileList = new List<PuzzleTile>();
        selectedTileList = new List<PuzzleTile>();
        posList = new List<Vector2>();
        availablePosList = new List<Vector2>();
        audioManager = FindObjectOfType<AudioManager>();
        eventSystem = FindObjectOfType<EventSystem>();
}
    private void Start()
    {
        tileList.AddRange(GetComponentsInChildren<PuzzleTile>());
        for (int i = 0; i < tileList.Count; i++)
        {
            posList.Add(tileList[i].gameObject.GetComponent<RectTransform>().anchoredPosition);
        }
        availablePosList.AddRange(posList);
        RandomizeTiles(false);
    }
    private void Update()
    {
        if (selectedTileList.Count >= MAX_SELECTION_COUNT)
        {
            CompareSelection();
        }
    }
    public void RandomizeTiles(bool useLerp)
    {
        for (int i = 0; i < tileList.Count; i++)
        {
            int index = Random.Range(0, availablePosList.Count);
            if (useLerp)
            {
                StartCoroutine(LerpTilePosition(i, index));
            }
            else
            {
                tileList[i].GetComponent<RectTransform>().anchoredPosition = availablePosList[index];
            }
            availablePosList.RemoveAt(index);
            
        }
        availablePosList.AddRange(posList);
        selectedTileList.Clear();
    }
    private IEnumerator LerpTilePosition(int i, int index)
    {
        float t = 0;
        Vector2 currentPos = tileList[i].GetComponent<RectTransform>().anchoredPosition;
        Vector2 targetPos = availablePosList[index];
        while (Vector2.Distance(currentPos, targetPos) > 0.1f)
        {
            t += Time.deltaTime;
            tileList[i].GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(currentPos, targetPos, t * shuffleSpeed);
            yield return new WaitForEndOfFrame();
        }
    }

    public void AddSelection(PuzzleTile tile)
    {
        if(!selectedTileList.Contains(tile))
        {
            selectedTileList.Add(tile);
        }
    }
    private void CompareSelection()
    {
        if (selectedTileList[0].GetSignature() == selectedTileList[1].GetSignature())
        {
            foreach (PuzzleTile tile in selectedTileList)
            {
                tile.Disable();
                audioManager.PlaySound(matchSound);
            }
        }
        else
        {
            foreach (PuzzleTile tile in selectedTileList)
            {
                tile.Deselect(new BaseEventData(eventSystem));
                audioManager.PlaySound(wrongSound);
            }
        }
        selectedTileList.Clear();
    }
}
