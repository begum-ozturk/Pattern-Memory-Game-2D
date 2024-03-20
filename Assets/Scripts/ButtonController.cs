using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public bool isActive = false;

    private Button button;
    private GameManager gameManager;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);

        gameManager = FindObjectOfType<GameManager>();

        ColorBlock colors = button.colors;
        colors.highlightedColor = gameManager.hoverColor;
        button.colors = colors;
    }

    void OnClick()
    {
        if (isActive)
        {
            gameManager.CheckSequence(transform.GetSiblingIndex());
        }
        else
        {
            gameManager.GameOver();
        }
    }
}
