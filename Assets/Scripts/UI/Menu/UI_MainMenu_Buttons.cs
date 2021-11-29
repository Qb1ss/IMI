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
        _startGameButton.onClick.AddListener(() => Button_StartGame());
    }


    private void Button_StartGame()
    {
        //==������ ����������� ������
        //==//==��� ������ ����� � �������, ������ ����������� �����
        SceneManager.LoadScene(1);
    }
}