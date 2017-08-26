using UnityEngine;

internal class AttackKeyFactory : ObjectFactory
{
    private static AttackKeyFactory _instance;

    public static AttackKeyFactory instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = new AttackKeyFactory();
            }
            return _instance;
        }
    }

    private AttackKeyFactory()
    {
        LoadSprites("KeyMen", "KeyKote", "KeyDo");
    }
}