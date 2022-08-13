using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText;
    [SerializeField]
    private TMPro.TextMeshProUGUI scoreText2;
    private int score = 0;
    [SerializeField]
    private GameObject startScreen;
    [SerializeField]
    private GameObject playScreen;
    [SerializeField]
    private GameObject endScreen;

    public bool isGameStarted = false;
    public bool isGameFinished = false;
    private void Start()
    {
        Application.targetFrameRate = 300;
    }
    void Update()
    {
        scoreText.text = score.ToString();
        scoreText2.text = score.ToString();
        if (Input.GetMouseButtonDown(0) && !isGameFinished)
        {
            score++;
        }
        if (isGameStarted)
        {
            startScreen.SetActive(false);
            playScreen.SetActive(true);
        }
        if (isGameFinished)
        {
            playScreen.SetActive(false);
            endScreen.SetActive(true);
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }
}
