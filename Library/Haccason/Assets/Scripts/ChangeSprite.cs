using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour {
    public Sprite[] sprites;

    SpriteRenderer MainSpriteRenderer;

    int spriteNumber = ButtonScript.CuisineGenre;
    // Start is called before the first frame update
    void Start () {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
        MainSpriteRenderer.sprite = sprites[spriteNumber];
        Debug.Log(spriteNumber);
    }

    // Update is called once per frame
    void Update () {

    }
}