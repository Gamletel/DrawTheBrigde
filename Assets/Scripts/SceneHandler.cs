using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void RestartLevel()
    {
        FinishCounter.ResetFinishes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        FinishCounter.ResetFinishes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
    }

    public void SkipLevel()
    {
        FinishCounter.ResetFinishes();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
