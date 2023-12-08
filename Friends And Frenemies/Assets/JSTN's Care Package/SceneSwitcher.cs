using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public string targetSceneName;

    public void SwitchScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
