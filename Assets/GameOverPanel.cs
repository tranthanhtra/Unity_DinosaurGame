using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
  // Start is called before the first frame update
  public Text score;
  public CharacterAction characterAction;

  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
  }

  private void OnEnable()
  {
    score.text = characterAction.scoreText.text;
    HomeManager.Instance.UpdateHighScore(score.text);
  }

  public void OnHomeClick()
  {
    EventManager.Instance.OnRestartTrigger();
    SceneManager.LoadScene("Home");
  }

  public void OnRestart()
  {
    gameObject.SetActive(false);
    EventManager.Instance.OnRestartTrigger();
  }
}