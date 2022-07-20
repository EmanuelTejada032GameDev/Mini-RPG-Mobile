using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
    [Header("Dependencies")]
    public SceneSO[] sceneDependencies;

    [Header("On scene readey")]
    public UnityEvent onDependenciesLoaded;

    private void Start()
    {
        StartCoroutine(LoadDependencies());
    }

    private IEnumerator LoadDependencies()
    {
        for (int i = 0; i < sceneDependencies.Length; i++)
        {
            SceneSO sceneToLoad = sceneDependencies[i];
            if (SceneManager.GetSceneByName(sceneToLoad.name).isLoaded == false)
            {
                var loadOperation = SceneManager.LoadSceneAsync(sceneToLoad.name, LoadSceneMode.Additive);
                while (loadOperation.isDone == false)
                {
                    yield return null;
                }
            }
        }
        if(onDependenciesLoaded != null)
            onDependenciesLoaded.Invoke();
    }

}
