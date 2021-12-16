using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UI_MainMenu_Buttons : MonoBehaviour
{
    [Header ("Buttons")]
    [SerializeField] private Button _startGameButton;


    private void Start()
    {
        _startGameButton.onClick.AddListener(() => Button_StartGame(SceneManager.sceneCount - 1));
    }


    private void Button_StartGame(int numberScene)
    {
        //переход на другую сцену, последовательно
        SceneTransitions sceneTransitions = new SceneTransitions();

        sceneTransitions.TransitionToNextScene(numberScene);
    }
}