using CodeBase;
using CodeBase.Interfaces;
using UnityEngine;

public class Rocket : MonoBehaviour, IInitializable, IDamagable
{
    [SerializeField] private float _maxFuel = 1000f;
    [SerializeField] private float _fuelTankMass = 600f;
    [SerializeField] private float _mass = 10;
    [SerializeField] private float _currentFuel;
    [SerializeField] private float _fuelConsumptionRate = 10f;
    [SerializeField] private float _health = 100f;

    private RocketMover _rocketMover;

    public float MaxFuel => _maxFuel;
    public float FuelTankMass => _fuelTankMass;
    public float Mass => _mass;
    public float CurrentFuel { get => _currentFuel; set => _currentFuel = value; }
    public float FuelConsumptionRate => _fuelConsumptionRate;
    public float Health => _health;

    public void Initialize()
    {
        _currentFuel = _maxFuel;
    }

    public void ApplyDamage(int value)
    {
        if (_health - value <= 0)
        {
            Explode();
            _health = 0;
        }
        
        _health -= value;
    }

    private void Explode()
    {
        Debug.Log("Explode");
    }
}
