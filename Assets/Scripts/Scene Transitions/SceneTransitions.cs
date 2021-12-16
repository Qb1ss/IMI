using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public void TransitionToNextScene(int numberScene)
    {
        SceneManager.LoadScene(numberScene + 1);
    }
}