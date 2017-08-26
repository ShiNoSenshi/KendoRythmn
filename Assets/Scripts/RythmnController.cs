using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RythmnController : MonoBehaviour {
    public GameObject spawnPosition;
    private float time;
    private IEnumerator<Attack> keys;
    private readonly float DELTA_BETWEEN_KEYS = 0.05f;
    private List<GameObject> keyObjects = new List<GameObject>();
    private List<GameObject> enemyObjects = new List<GameObject>();

    private void Start()
    {
        keys = GetKey();
    }

    // Update is called once per frame
    void Update () {
        time += Time.deltaTime;
        if(time > DELTA_BETWEEN_KEYS)
        {
            if (keys.MoveNext())
            {
                var key = keys.Current;
                ShowNextKey(key);
            }
            time = 0;
            MoveKeys();
            DestroyOldKeys();
        }
	}

    private void DestroyOldKeys()
    {
        if (keyObjects.Count > 0 && keyObjects[0].transform.position.x < -18)
        {
            Destroy(keyObjects[0]);
            keyObjects.Remove(keyObjects[0]);

            Destroy(enemyObjects[0]);
            enemyObjects.Remove(enemyObjects[0]);
        }
    }

    private void MoveKeys()
    {
        foreach (var keyObject in keyObjects)
            keyObject.transform.position -= new Vector3(0.2f, 0, 0);

        foreach (var enemyObject in enemyObjects)
            enemyObject.transform.position -= new Vector3(0.2f, 0, 0);
    }

    private void ShowNextKey(Attack key)
    {
        if(spawnPosition != null)
        {
            if (key != Attack.Idle)
            {
                var keyObject = AttackKeyFactory.instance.GenerateObject(key, spawnPosition.transform.position, new Vector3(0.2f, 0.2f));
                if (keyObject != null)
                    keyObjects.Add(keyObject); 
                var enemy = EnemyFactory.instance.GenerateObject(ComputeEnemyAttack(key), spawnPosition.transform.position + new Vector3(0,2), Vector3.one, true);
                if (enemy != null)
                    enemyObjects.Add(enemy);
            }
        }
    }

    private Attack ComputeEnemyAttack(Attack key)
    {
        switch (key)
        {
            case Attack.Men:
                return Attack.Kote;
            case Attack.Kote:
                return Attack.Do;
            case Attack.Do:
                return Attack.Men;
            default:
                return Attack.Idle;
        }
    }

    private IEnumerator<Attack> GetKey()
    {
        TextAsset keys = (TextAsset)Resources.Load("sample");
        foreach(char key in keys.text)
        {
            switch(key)
            {
                case 'm':
                    yield return Attack.Men;
                    break;
                case 'd':
                    yield return Attack.Do;
                    break;
                case 'k':
                    yield return Attack.Kote;
                    break;
                default:
                    yield return Attack.Idle;
                    break;
            }
        }
    }
}
