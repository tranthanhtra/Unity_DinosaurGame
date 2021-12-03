using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour
{
  // Start is called before the first frame update
  // public Button playButton;
  private static int highestScore;
  public TextMeshProUGUI showScore;
  public Scene homescene;

  public AudioSource backgroundMusic;
  public AudioClip buttonClick;
  
  public static HomeManager Instance;

  private void Start()
  {
    Instance = this; 
    showScore.text = highestScore.ToString();
    backgroundMusic.Play();
  }

  // Update is called once per frame
  private void Update()
  {
    if (homescene.isLoaded)
    {
      showScore.text = highestScore.ToString();
    }
  }


  public void OnPlayButtonClicked()
  {
    backgroundMusic.PlayOneShot(buttonClick, 1);
    SceneManager.LoadScene("Game");
  }
  public void UpdateHighScore(string score)
  {
    var parseScore = Int32.Parse(score);
    
    highestScore = parseScore > highestScore ? parseScore : highestScore;
    Debug.Log(highestScore);
  }
}