using CodeBase;
using CodeBase.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour, IInitializable, IDamagable
{
    [SerializeField] private float _maxFuel = 1000f;
    [SerializeField] private float _fuelTankMass = 600f;
    [SerializeField] private float _mass = 10;
    [SerializeField] private float _currentFuel;
    [SerializeField] private float _fuelConsumptionRate = 10f;
    [SerializeField] private float _health = 100f;
    [SerializeField] private float _damageMultiplier = .1f;

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
        _rocketMover = GetComponent<RocketMover>();
    }

    public void ApplyDamage(int value)
    {
        float absoluteSpeedSum = Mathf.Abs(_rocketMover.CurrentSpeed.x) + Mathf.Abs(_rocketMover.CurrentSpeed.y);
        int damage = Mathf.RoundToInt(value * _damageMultiplier * absoluteSpeedSum);


        if (_health - damage <= 0)
        {
            Explode();
            _health = 0;
        }
        _health -= damage;
        Debug.Log($"Rocket hit damage: {damage} Current health: {_health}");
    }

    private void Explode()
    {
        Debug.Log("Explode");
        SceneManager.LoadScene(0);
    }
}
