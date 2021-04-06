using TMPro;
using UnityEngine;

public class EndMenu : MainMenu
{
    public TextMeshProUGUI messageText;
    public TextMeshProUGUI nextLevelText;
    public GameObject nextLevelButton;

    public const int SceneIndex = 3;
    public static int NextLevelSceneIndex { get; set; }
    public static string Message { get; set; }
    public static bool Retry { get; set; }

    private void Start()
    {
        nextLevelText.text = Retry ? "Retry" : "Next";
        nextLevelButton.SetActive(NextLevelSceneIndex > 0 && NextLevelSceneIndex < SceneIndex);
        messageText.text = Message;
    }

    public void OpenNextLevel()
    {
        OpenScene(NextLevelSceneIndex);
    }
}