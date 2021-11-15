// ================================================================================================================
// UTS Praktik - SceneHandler.cs
// 
// Author: Wahyu Candra
// Date:   11/11/2021
// ================================================================================================================

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField] private float delay = 0f;
    public void ChangeSceneWithDelay(string sceneName)
    {
        StartCoroutine(DelaySceneChange(sceneName));
    }
    private IEnumerator DelaySceneChange(string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
    }
}
