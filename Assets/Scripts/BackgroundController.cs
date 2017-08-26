using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {
    public Sprite background;
    private float time;
    private List<GameObject> backgroundObjects = new List<GameObject>();


    // Use this for initialization
    void Start ()
    {
        CreateBackground(new Vector3(0, 0));
    }

    private void CreateBackground(Vector3 position)
    {
        var backgroundObject = new GameObject("Background");
        backgroundObject.transform.position = position;
        backgroundObject.AddComponent<SpriteRenderer>();
        var spriteRenderer = backgroundObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = background;
        backgroundObjects.Add(backgroundObject);
    }

    // Update is called once per frame
    void Update ()
    {
        DestroyAndCreateBackgrounds();
        UpdatePositions();
    }

    private void DestroyAndCreateBackgrounds()
    {
        if(backgroundObjects.Count > 0)
        { 
            if(backgroundObjects[0].transform.position.x < -18)
            {
                Destroy(backgroundObjects[0]);
                backgroundObjects.Remove(backgroundObjects[0]);
            }

            if (backgroundObjects[backgroundObjects.Count - 1].transform.position.x < 1)
                CreateBackground(new Vector3(18, 0));
        }
    }

    private void UpdatePositions()
    {
        time += Time.deltaTime;
        if (time > 0.05)
        {
            MoveBackgroundObjects();
            time = 0;
        }
    }

    private void MoveBackgroundObjects()
    {
        foreach(var backgroundObject in backgroundObjects)
        {
            backgroundObject.transform.position -= new Vector3(0.2f, 0, 0);
        }
    }
}
