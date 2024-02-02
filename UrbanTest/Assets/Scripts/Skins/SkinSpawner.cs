using System;
using System.Collections.Generic;
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
    private SkinCollector _skinCollector;

    private List<WeaponSkin> _spawnedWeaponSkin;
    private List<AmmoSkin> _spawnedAmmoSkin;
    private List<ArmorSkin> _spawnedArmorSkin;

    public SkinSpawner (SkinFactory skinFactory, SkinCollector skinCollector)
    {
        _skinFactory = skinFactory;
        _skinCollector = skinCollector;

        _spawnedAmmoSkin = new List<AmmoSkin>();
        _spawnedArmorSkin = new List<ArmorSkin>();
        _spawnedWeaponSkin = new List<WeaponSkin>();
    }

    public void Spawn()
    {
        WeaponSpawn();
        ArmorSpawn();
        AmmoSpawn();

        _skinCollector.Initialize(_spawnedWeaponSkin, _spawnedArmorSkin, _spawnedAmmoSkin);
    }

    private void WeaponSpawn()
    {
        for (int i = 0; i < Random.Range(1, MaxRandomNumber); i++)
        {
            var weapon = _skinFactory.GetWeapon((WeaponSkins)Random.Range(0, Enum.GetValues(typeof(WeaponSkins)).Length));
            weapon.transform.position = new Vector2(Random.Range(MinXPosition, MaxXPosition), Random.Range(MinYPosition, MaxYPosition));

            _spawnedWeaponSkin.Add(weapon);
        }
    }

    private void ArmorSpawn()
    {
        for (int i = 0; i < Random.Range(1, MaxRandomNumber); i++)
        {
            var armor = _skinFactory.GetArmor((ArmorSkins)Random.Range(0, Enum.GetValues(typeof(ArmorSkins)).Length));
            armor.transform.position = new Vector2(Random.Range(MinXPosition, MaxXPosition), Random.Range(MinYPosition, MaxYPosition));

            _spawnedArmorSkin.Add(armor);
        }
    }

    private void AmmoSpawn()
    {
        for (int i = 0; i < Random.Range(1, MaxRandomNumber); i++)
        {
            var ammo = _skinFactory.GetAmmo((AmmoSkins)Random.Range(0, Enum.GetValues(typeof(AmmoSkins)).Length));
            ammo.transform.position = new Vector2(Random.Range(MinXPosition, MaxXPosition), Random.Range(MinYPosition, MaxYPosition));

            _spawnedAmmoSkin.Add(ammo);
        }
    }
}
