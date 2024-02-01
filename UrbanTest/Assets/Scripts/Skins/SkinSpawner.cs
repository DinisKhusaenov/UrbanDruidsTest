using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SkinSpawner
{
    private const int MaxRandomNumber = 6;
    private const float MinXPosition = -7;
    private const float MaxXPosition = 7;
    private const float MinYPosition = -4;
    private const float MaxYPosition = 4;

    private SkinFactory _skinFactory;

    public SkinSpawner (SkinFactory skinFactory)
    {
        _skinFactory = skinFactory;
    }

    public void Spawn()
    {
        WeaponSpawn();
        ArmorSpawn();
        AmmoSpawn();
    }

    private void WeaponSpawn()
    {
        for (int i = 0; i < Random.Range(1, MaxRandomNumber); i++)
        {
            var weapon = _skinFactory.GetWeapon((WeaponSkins)Random.Range(0, Enum.GetValues(typeof(WeaponSkins)).Length));
            weapon.transform.position = new Vector2(Random.Range(MinXPosition, MaxXPosition), Random.Range(MinYPosition, MaxYPosition));
        }
    }

    private void ArmorSpawn()
    {
        for (int i = 0; i < Random.Range(1, MaxRandomNumber); i++)
        {
            var armor = _skinFactory.GetArmor((ArmorSkins)Random.Range(0, Enum.GetValues(typeof(ArmorSkins)).Length));
            armor.transform.position = new Vector2(Random.Range(MinXPosition, MaxXPosition), Random.Range(MinYPosition, MaxYPosition));
        }
    }

    private void AmmoSpawn()
    {
        for (int i = 0; i < Random.Range(1, MaxRandomNumber); i++)
        {
            var ammo = _skinFactory.GetAmmo((AmmoSkins)Random.Range(0, Enum.GetValues(typeof(AmmoSkins)).Length));
            ammo.transform.position = new Vector2(Random.Range(MinXPosition, MaxXPosition), Random.Range(MinYPosition, MaxYPosition));
        }
    }
}
