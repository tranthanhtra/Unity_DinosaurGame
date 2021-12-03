using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour
{
  public GameObject backgroundImagePrefab;
  public GameObject groundImagePrefab;
  public GameObject treeImagePrefab;

  public GameObject background1;
  public GameObject background2;

  public GameObject ground1;
  public GameObject ground2;

  public GameObject tree1;
  public GameObject tree2;

  // Start is called before the first frame update
  void Start()
  {
    background1 = SetBackground(backgroundImagePrefab, Vector3.up * 3.14f, new Vector3(1.5f, 1, 0));
    background2 = SetBackground(backgroundImagePrefab, new Vector3(28f, 3.14f, 0f), new Vector3(1.5f, 1, 0));

    ground1 = SetBackground(groundImagePrefab, Vector3.up * 4.21f, new Vector3(1.5f, 1.81f, 0));
    ground2 = SetBackground(groundImagePrefab, new Vector3(28f, 4.21f, 0f), new Vector3(1.5f, 1.81f, 0));
    
    tree1 = SetBackground(treeImagePrefab, Vector3.up * 1.77f, new Vector3(1.5f, 1f, 0));
    tree2 = SetBackground(treeImagePrefab, new Vector3(28f, 1.77f, 0f), new Vector3(1.5f, 1f, 0));

  }

  private void Update()
  {
    if (GetXPosition(background1) < -28f)
    {
      SetPosition(background1, new Vector3(28f, 3.14f, 0f));
    }

    if (GetXPosition(background2) < -28f)
    {
      SetPosition(background2, new Vector3(28f, 3.14f, 0f));
    }
    
    if (GetXPosition(ground1) < -28f)
    {
      SetPosition(ground1, new Vector3(28f, 4.21f, 0f));
    }
    
    if (GetXPosition(ground2) < -28f)
    {
      SetPosition(ground2, new Vector3(28f, 4.21f, 0f));
    }
    
    if (GetXPosition(tree1) < -28f)
    {
      SetPosition(tree1, new Vector3(28f, 1.77f, 0f));
    }
    
    if (GetXPosition(tree2) < -28f)
    {
      SetPosition(tree2, new Vector3(28f, 1.77f, 0f));
    }
  }

  // Update is called once per frame
  private void LateUpdate()
  {
    if (EventManager.Instance.start)
    {
      Vector2 pos1 = ground1.transform.position;
      float deltaX = Time.deltaTime * 7;
      pos1.x -= deltaX;
      ground1.transform.position = pos1;
      Vector2 pos2 = ground2.transform.position;
      pos2.x -= deltaX;
      ground2.transform.position = pos2;

      pos1 = background1.transform.position;
      deltaX = Time.deltaTime * 3;
      pos1.x -= deltaX;
      background1.transform.position = pos1;
      pos2 = background2.transform.position;
      pos2.x -= deltaX;
      background2.transform.position = pos2;
      
      
      pos1 = tree1.transform.position;
      deltaX = Time.deltaTime * 7;
      pos1.x -= deltaX;
      tree1.transform.position = pos1;
      pos2 = tree2.transform.position;
      pos2.x -= deltaX;
      tree2.transform.position = pos2;
    }
  }

  private GameObject SetBackground(GameObject prefab, Vector3 position, Vector3 scale)
  {
    var background = Instantiate(prefab, position, Quaternion.identity);
    background.transform.localScale = scale;

    return background;
  }

  private void SetPosition(GameObject background, Vector3 position)
  {
    background.transform.position= position;
  }
  
  private float GetXPosition(GameObject gameObject)
  {
    return gameObject.transform.position.x;
  }
}