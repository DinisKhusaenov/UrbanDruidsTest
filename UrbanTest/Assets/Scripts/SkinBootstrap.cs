using System.Collections.Generic;
using UnityEngine;

public class SkinBootstrap : MonoBehaviour
{
    [SerializeField] private List<WeaponSkin> _weapons;
    [SerializeField] private List<ArmorSkin> _armors;
    [SerializeField] private List<AmmoSkin> _ammos;

    private SkinSpawner _skinSpawner;
    private SkinFactory _skinFactory;
    private SkinCollector _skinCollector;

    public void Initialize(SkinCollector skinCollector)
    {
        _skinCollector = skinCollector;
        _skinFactory = new SkinFactory(_weapons, _ammos, _armors);
        _skinSpawner = new SkinSpawner(_skinFactory, skinCollector);

        _skinSpawner.Spawn();
    }
}
