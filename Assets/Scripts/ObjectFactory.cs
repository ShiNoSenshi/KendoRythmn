using UnityEngine;

internal abstract class ObjectFactory
{
    private static AttackKeyFactory _instance;
    private Sprite menSprite;
    private Sprite koteSprite;
    private Sprite doSprite;

    /*public static AttackKeyFactory instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new ObjectFactory();
            }
            return _instance;
        }
    }*/

    protected void LoadSprites(string menResource, string koteResource, string doResource)
    {
        Texture2D menTex = (Texture2D)Resources.Load(menResource);
        menSprite = Sprite.Create(menTex, new Rect(0.0f, 0.0f, menTex.width, menTex.height), new Vector2(0.5f, 0.5f), 100.0f);

        Texture2D koteTex = (Texture2D)Resources.Load(koteResource);
        koteSprite = Sprite.Create(koteTex, new Rect(0.0f, 0.0f, koteTex.width, koteTex.height), new Vector2(0.5f, 0.5f), 100.0f);

        Texture2D doTex = (Texture2D)Resources.Load(doResource);
        doSprite = Sprite.Create(doTex, new Rect(0.0f, 0.0f, doTex.width, doTex.height), new Vector2(0.5f, 0.5f), 100.0f);
    }

    /*private ObjectFactory()
    {
        LoadSprites();
    }*/

    public GameObject GenerateObject(Attack key, Vector3 position, Vector3 scale, bool flipX = false)
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

        var keyObject = new GameObject("KeyObject");
        keyObject.transform.position = position;
        keyObject.transform.localScale = scale;
        keyObject.AddComponent<SpriteRenderer>();
        var spriteRenderer = keyObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.flipX = flipX;
        return keyObject;
    }
}