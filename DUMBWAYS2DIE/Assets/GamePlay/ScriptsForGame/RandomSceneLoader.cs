using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class RandomSceneLoader : MonoBehaviour
{
    [SerializeField] private List<string> sceneNames = new List<string>(); // List of scenes to pick from

    private void Start()
    {
        if (sceneNames.Count == 0)
        {
            Debug.LogError("No scenes assigned in the list!");
            return;
        }
        LoadRandomScene();
    }

    private void LoadRandomScene()
    {
        string randomScene = sceneNames[Random.Range(0, sceneNames.Count)];
        SceneManager.LoadScene(randomScene);
    }

    // Call this method when the scene is completed
    public void OnSceneCompleted()
    {
        LoadRandomScene();
    }
}

