using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CharacterAction : MonoBehaviour
{
  // Start is called before the first frame update
  public Rigidbody2D rb;
  public Animator anim;
  private bool _clickEnable;
  public Text scoreText;
  private float _timer;
  private bool _firstFire;
  private int _prevFire;

  public AudioSource sound;
  public AudioClip runningAudio;
  public AudioClip jumpAudio;
  public AudioClip dieAudio;

  public void SetPrevFire(int time)
  {
    _prevFire = time;
  }

  public void SetFirstFire(bool first)
  {
    _firstFire = first;
  }

  public GameObject bullet;

  public void SetTimer(float timer)
  {
    _timer = timer;
  }

  void Start()
  {
    _clickEnable = true;
    rb = GetComponent<Rigidbody2D>();
    _timer = 0.0f;
    _firstFire = true;
    _prevFire = 0;
  }

  // Update is called once per frame
  void Update()
  {
    if (EventManager.Instance.start)
    {
      _timer += Time.deltaTime;
      int seconds = Mathf.FloorToInt(_timer % 60);
      scoreText.text = seconds.ToString();

      if (Input.GetKeyDown("right") && ((seconds - _prevFire) > 1 || _firstFire))
      {
        _prevFire = seconds;
        FireBullet();
        _firstFire = false;
      }

      if (Input.GetKeyDown("space") && _clickEnable)
      {
        Jump();
        _clickEnable = false;
      }

      if (Time.timeScale == 0)
      {
        sound.Pause();
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.name == "Square" && !_clickEnable)
    {
      _clickEnable = true;
      anim.SetTrigger("isRun");
      sound.Play();
    }
  }

  private void Jump()
  {
    anim.SetTrigger("isJump");
    rb.AddForce(transform.up * 4000f);
    sound.PlayOneShot(jumpAudio);
    sound.PlayDelayed(1f);
  }

  public void FireBullet()
  {
    GameObject instance = Instantiate(bullet, new Vector3(-1.7f, -0f, 0f), Quaternion.identity);
    Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
    rb.velocity = new Vector2(7f, 0f);
    instance.tag = "Bullet";
  }
}