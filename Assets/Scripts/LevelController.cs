using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void LoadNextLevel()
    {
        StartCoroutine(LoadNextLevelAfterSeconds());
    }

    public void Restart()
    {
        StartCoroutine(RestartAfterSeconds());
    }
    
    private IEnumerator LoadNextLevelAfterSeconds()
    {
        var delay = new WaitForSeconds(2f);
        yield return delay;
        if (SceneManager.GetActiveScene().buildIndex + 1 > SceneManager.sceneCount)
        {
            SceneManager.LoadSceneAsync(0);
        }
        else
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private IEnumerator RestartAfterSeconds()
    {
        var delay = new WaitForSeconds(2f);
        yield return delay;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}