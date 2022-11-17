using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool IsGameActive = false;
    public List<GameObject> Target;
    public int Score = 0;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI GameOverText;
    // public TextMeshProUGUI GametitleText;
   // public Button Startbutton;
    public GameObject StartScene;
    public Button RestartButton;
    public int SpawnRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame(int difficulty)
    {
       // GametitleText.gameObject.SetActive(false);
        //Startbutton.gameObject.SetActive(false);
        StartScene.gameObject.SetActive(false);
        ScoreText.gameObject.SetActive(true);
        IsGameActive = true;
        ScoreText.text = "Score " + Score;
        SpawnRate /= difficulty;
        StartCoroutine(SpawnTarget());

    }



    public void UpdateScore(int addToScore)
    {
        Score += addToScore;
        Debug.Log("Score: " + Score.ToString());
        ScoreText.text = "Score: " + Score.ToString();
    }
    IEnumerator SpawnTarget()
    {
        while(IsGameActive)
        {
            yield return new WaitForSeconds(SpawnRate);
            int index = Random.Range(0, Target.Count);
            Instantiate(Target[index]);
        }
        
    }
    public void GameOver()
    {
        IsGameActive = false;
        GameOverText.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}