using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneSwitcher : MonoBehaviour
{
    public string targetSceneName;

    public void SwitchScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}
