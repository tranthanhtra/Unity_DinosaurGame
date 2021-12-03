using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EventManager : MonoBehaviour
{
  public List<GameObject> ActiveEnemies = new List<GameObject>();

  public Animator anim;

  public static EventManager Instance;

  public BackgroundManager backgroundManager;

  public GameObject character;
  public CharacterAction characterAction;

  public GameObject gameOverPanel;
  public GameObject settingPanel;

  public AudioSource gameAudio;
  public AudioClip dying;
  public AudioClip bulletHit;
  public AudioClip buttonClick;
  
  public int countdownTime;
  public Text countdownDisplay;

  public bool start;

  public ParticleSystem firework;

  // public Image backgroundImage;

  // Start is called before the first frame update
  void Start()
  {
    Instance = this;
    gameAudio.Play();
    start = false;
    countdownTime = 3;
    firework.Stop();
    StartCoroutine(CountdownToStart());
    // backgroundImage.material.SetTextureOffset("New Material", Vector2.left * 7f);
  }

  private void Update()
  {
  }

  public void GameOver()
  {
    gameAudio.PlayOneShot(dying);
    gameAudio.PlayDelayed(2f);
    firework.Play();
    gameOverPanel.SetActive(true);
  }

  public void OnSettingClick()
  {
    Time.timeScale = 0;
    settingPanel.SetActive(true);
  }

  public void OnRestartTrigger()
  {
    firework.Stop();
    characterAction.anim.Play("char_idle");
    characterAction.sound.Pause();
    gameAudio.Play();
    anim.SetTrigger("isRun");
    
    for (var i = 0; i < ActiveEnemies.Count; i++)
    {
      ActiveEnemies[i].SetActive(false);
    }

    ActiveEnemies.RemoveRange(0, ActiveEnemies.Count);


    var allBullet = GameObject.FindGameObjectsWithTag("Bullet");
    foreach (var obj in allBullet)
    {
      Destroy(obj);
    }

    Time.timeScale = 1.0f;

    characterAction.SetTimer(0.0f);
    characterAction.SetPrevFire(0);
    characterAction.SetFirstFire(true);

    character.GetComponent<Rigidbody2D>().position = new Vector2(-2.5f, -1.4f);
    character.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
  }

  public void OnHitBullet()
  {
    gameAudio.PlayOneShot(bulletHit, 0.75f);
  }

  public void OnButtonClick()
  {
    gameAudio.PlayOneShot(buttonClick,1f);
  }
  
  private IEnumerator CountdownToStart()
  {
    Debug.Log(countdownTime);
    while (countdownTime > 0)
    {
      countdownDisplay.text = countdownTime.ToString();
      yield return new WaitForSeconds(1f);
      countdownTime--;
    }

    countdownDisplay.text = "GO!";

    

    yield return new WaitForSeconds(1f);
        
    countdownDisplay.gameObject.SetActive(false);
    
    characterAction.anim.SetTrigger("isRun");
    // backgroundManager.background1.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, 0f);
    // backgroundManager.background2.GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, 0f);
    // backgroundManager.ground1.GetComponent<Rigidbody2D>().velocity = new Vector2(-7f, 0f);
    // backgroundManager.ground2.GetComponent<Rigidbody2D>().velocity = new Vector2(-7f, 0f);
    // backgroundManager.tree1.GetComponent<Rigidbody2D>().velocity = new Vector2(-7f, 0f);
    // backgroundManager.tree2.GetComponent<Rigidbody2D>().velocity = new Vector2(-7f, 0f);

    start = true;
  }

}