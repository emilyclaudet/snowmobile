using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
  public Sprite defaultSprite;
  public Sprite holdingCollectableSprite;
  [SerializeField] float destroyDelay = 1f;
  bool hasCollectable;  
  private SpriteRenderer spriteRenderer;
  public int itemsToGive;
  private int itemsGiven;
  public GameOverScreen GameOverScreen;
  public AudioSource collectSoundEffect;
  public AudioSource deliverSoundEffect;

  void Start() 
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.sprite = defaultSprite;
    itemsGiven = 0;
  }

  void Update()
  {
    if(itemsGiven == itemsToGive) 
    {
      GameOver();
    }
  }

  public void GameOver() 
  {
    GameOverScreen.Setup();
  }
  void OnCollisionEnter2D(Collision2D other)
  {
    Debug.Log("You crashed!");
  }
  void OnTriggerEnter2D(Collider2D other)
  {
      if(other.tag == "Collectable" && !hasCollectable)
      {
        Debug.Log("Collected item!");
        hasCollectable = true;
        spriteRenderer.sprite = holdingCollectableSprite;
        collectSoundEffect.Play();
        Destroy(other.gameObject, destroyDelay);
      }

      if(other.tag == "Friend" && hasCollectable)
      {
        Debug.Log("Given item to friend!");
        spriteRenderer.sprite = defaultSprite;
        hasCollectable = false;
        deliverSoundEffect.Play();        
        itemsGiven += 1;
      }

  }

}

