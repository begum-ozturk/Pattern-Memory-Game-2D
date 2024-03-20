using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Button[] buttons;
    public float startDelay = 1f;
    public float highlightDuration = 0.5f;
    private int winCount = 0;
    private List<int> sequence = new List<int>();

    public GameObject gameOverUI;

    public string nextLevelName;
    public int Score;

    public Color hoverColor;

    void Start()
    {
        StartCoroutine(StartGame());
        // PlayerPrefs'ten Score'u alın
        Score = PlayerPrefs.GetInt("Score", 0);
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            GameOver();
        }
    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(startDelay);

        int buttonCount = Mathf.Min(winCount + 1, buttons.Length - 1);

        for (int i = 0; i < buttonCount; i++)
        {
            int randomButtonIndex = Random.Range(0, buttons.Length);
            sequence.Add(randomButtonIndex);
            ButtonController buttonController = buttons[randomButtonIndex].GetComponent<ButtonController>();
            Debug.Log("Buton" + randomButtonIndex + " aktif");
            buttonController.isActive = true;

            StartCoroutine(HighlightButton(buttons[randomButtonIndex]));
            yield return new WaitForSeconds(highlightDuration + 0.3f);
        }
    }

    IEnumerator HighlightButton(Button button)
    {
        Color originalColor = button.image.color;
        Color highlightColor = Color.green;

        button.image.color = highlightColor;

        yield return new WaitForSeconds(highlightDuration);

        button.image.color = originalColor;
    }

    public void GameWon()
    {
        winCount++;
        Score++;
        PlayerPrefs.SetInt("Score", Score);
        if (winCount >= buttons.Length - 1)
        {
            SceneManager.LoadScene(nextLevelName);
        }
        else
        {
            StartCoroutine(StartGame());
        }
    }

    public void GameOver()
    {

        gameOverUI.SetActive(true);
        //SceneManager.LoadScene("Level1");
    }

    public void CheckSequence(int buttonIndex)
    {
        if (sequence.Count == 0 || sequence[0] != buttonIndex)
        {
            GameOver();
            return;
        }

        sequence.RemoveAt(0);
        if (sequence.Count == 0)
        {
            GameWon();
        }
    }

    public void Retry()
    {
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
        SceneManager.LoadScene("Level1");

    }
    public void Menu()
    {
        Score = 0;
        PlayerPrefs.SetInt("Score", Score);
        SceneManager.LoadScene("MainMenu");
    }
}
