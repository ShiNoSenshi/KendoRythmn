using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Attack currentStatus = Attack.Idle;
    private Sprite idleSprite;
    private Sprite menSprite;
    private Sprite koteSprite;
    private Sprite doSprite;
    private float time;
    private bool attacked;

    private void Start()
    {
        LoadSprites();
    }

    private void LoadSprites()
    {
        Texture2D idleTex = (Texture2D) Resources.Load("CharacterIdle");
        idleSprite = Sprite.Create(idleTex, new Rect(0.0f, 0.0f, idleTex.width, idleTex.height), new Vector2(0.5f, 0.5f), 100.0f);

        Texture2D menTex = (Texture2D)Resources.Load("CharacterMen");
        menSprite = Sprite.Create(menTex, new Rect(0.0f, 0.0f, menTex.width, menTex.height), new Vector2(0.5f, 0.5f), 100.0f);

        Texture2D koteTex = (Texture2D)Resources.Load("CharacterKote");
        koteSprite = Sprite.Create(koteTex, new Rect(0.0f, 0.0f, koteTex.width, koteTex.height), new Vector2(0.5f, 0.5f), 100.0f);

        Texture2D doTex = (Texture2D)Resources.Load("CharacterDo");
        doSprite = Sprite.Create(doTex, new Rect(0.0f, 0.0f, doTex.width, doTex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    private bool WaitForUserInput()
    {
        bool updated = false;
        if (Input.GetAxis("Men") != 0.0f)
            updated = UpdateSprite(Attack.Men);
        else if (Input.GetAxis("Kote") != 0.0f)
            updated = UpdateSprite(Attack.Kote);
        else if (Input.GetAxis("Do") != 0.0f)
            updated = UpdateSprite(Attack.Do);
        else
            updated = UpdateSprite(Attack.Idle);
        return updated;
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        if (!attacked || time > 1f)
        {
            attacked = WaitForUserInput();
            if (attacked)
                time = 0;
        }
    }

    private bool UpdateSprite(Attack status)
    {
        bool updated = false;
        if (currentStatus != status)
        {
            switch (status)
            {
                case Attack.Men:
                    ((SpriteRenderer)gameObject.GetComponent<SpriteRenderer>()).sprite = menSprite;
                    currentStatus = Attack.Men;
                    break;
                case Attack.Kote:
                    ((SpriteRenderer)gameObject.GetComponent<SpriteRenderer>()).sprite = koteSprite;
                    currentStatus = Attack.Kote;
                    break;
                case Attack.Do:
                    ((SpriteRenderer)gameObject.GetComponent<SpriteRenderer>()).sprite = doSprite;
                    currentStatus = Attack.Do;
                    break;
                default:
                    ((SpriteRenderer)gameObject.GetComponent<SpriteRenderer>()).sprite = idleSprite;
                    currentStatus = Attack.Idle;
                    break;
            }
            updated = true;
        }
        return updated;
    }
}
