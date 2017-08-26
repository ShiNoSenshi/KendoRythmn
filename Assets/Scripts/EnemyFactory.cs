using UnityEngine;
using UnityEditor;

internal class EnemyFactory : ObjectFactory
{
    private static EnemyFactory _instance;

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

    private EnemyFactory()
    {
        LoadSprites("CharacterMen", "CharacterKote", "CharacterDo");
    }
}