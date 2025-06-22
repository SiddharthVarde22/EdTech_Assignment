using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadQuizScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadSimulation()
    {
        SceneManager.LoadScene(2);
    }
}
