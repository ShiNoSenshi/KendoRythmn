using UnityEngine;
using UnityEditor;

internal class EnemyFactory : ObjectFactory
{
    private static EnemyFactory _instance;
    /*private Sprite menSprite;
    private Sprite koteSprite;
    private Sprite doSprite;*/

    public static EnemyFactory instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EnemyFactory();
            }
            return _instance;
        }
    }

    /*private void LoadSprites()
    {
        Texture2D menTex = (Texture2D)Resources.Load("CharacterMen");
        menSprite = Sprite.Create(menTex, new Rect(0.0f, 0.0f, menTex.width, menTex.height), new Vector2(0.5f, 0.5f), 100.0f);

        Texture2D koteTex = (Texture2D)Resources.Load("CharacterKote");
        koteSprite = Sprite.Create(koteTex, new Rect(0.0f, 0.0f, koteTex.width, koteTex.height), new Vector2(0.5f, 0.5f), 100.0f);

        Texture2D doTex = (Texture2D)Resources.Load("CharacterDo");
        doSprite = Sprite.Create(doTex, new Rect(0.0f, 0.0f, doTex.width, doTex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }*/

    private EnemyFactory()
    {
        LoadSprites("CharacterMen", "CharacterKote", "CharacterDo");
    }

    /*public GameObject GenerateEnemy(Attack key, Vector3 position)
    {
        Sprite sprite = null;
        switch (key)
        {
            case Attack.Men:
                sprite = menSprite;
                break;
            case Attack.Kote:
                sprite = koteSprite;
                break;
            case Attack.Do:
                sprite = doSprite;
                break;
            default:
                return null;
        }

        var enemyObject = new GameObject("KeyObject");
        enemyObject.transform.position = position;
        enemyObject.transform.localScale = new Vector3(0.2f, 0.2f);
        enemyObject.AddComponent<SpriteRenderer>();
        var spriteRenderer = enemyObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        return enemyObject;
    }*/
}