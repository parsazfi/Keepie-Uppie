using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text ScoreText;
    private int score;
    void Start()
    {
        score = 0;
        ScoreText.text = score.ToString();
    }

    public void AddScore(int value = 1)
    {
        score += value;
        ScoreText.text = score.ToString();
    }

    public void Reset()
    {
        score = 0;
        ScoreText.text = score.ToString();
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }
}
