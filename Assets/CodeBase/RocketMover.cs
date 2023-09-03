using CodeBase.Interfaces;
using UnityEngine;

namespace CodeBase
{
    public class RocketMover : MonoBehaviour, IInitializable
    {
        [SerializeField] private float _initialThrust = 1000f;
        [SerializeField] private float _maxSpeed = 20f;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private Vector3 _currentSpeed;

        private readonly float _maxAirResistance = 2f;
        private readonly float _minAirResistance = 0.2f;

        private float _sideVelocity;
        private float _rotateVelocity;
        private bool _canMove;
        private Rocket _rocket;
        
        public bool CanMove { get => _canMove; set => _canMove = value; }
        public Vector3 CurrentSpeed => _currentSpeed;

        private const float Gravity = 9.81f;

        public void Initialize()
        {
            _rocket = GetComponent<Rocket>();
        }

        private void FixedUpdate()
        {
            if (_canMove && _rocket.CurrentFuel > 0)
            {
                ConsumeFuel();
                ApplyThrust();
            }

            ApplyGravity();

            UpdatePosition();
            
            ApplySideVelocity();
        }
        
        public void RotateByZ(float rotateAxis)
        {
            _rotateVelocity = rotateAxis;
            transform.rotation *= Quaternion.Euler(0, 0, _rotateVelocity * _rotationSpeed * Time.fixedDeltaTime);;
        }

        private void ApplyThrust()
        {
            float thrustForce = (_initialThrust * _rocket.CurrentFuel) / (_rocket.Mass + _rocket.FuelTankMass) * Time.fixedDeltaTime;
            _currentSpeed += transform.up * thrustForce;

            float airResistance = GetAirResistance();
            _currentSpeed -= _currentSpeed.normalized * airResistance * Time.fixedDeltaTime;

            float sideForce = -_rotateVelocity * _rotationSpeed * Time.fixedDeltaTime;
            _sideVelocity += sideForce;
            _canMove = false;
        }

        private void UpdatePosition()
        {
            _currentSpeed = Vector3.ClampMagnitude(_currentSpeed, _maxSpeed);
            transform.position += _currentSpeed * Time.fixedDeltaTime;
        }

        private void ConsumeFuel()
        {
            float fuelUsed = _rocket.FuelConsumptionRate * Time.fixedDeltaTime;
            _rocket.CurrentFuel = Mathf.Max(_rocket.CurrentFuel - fuelUsed, 0f);
        }
        
        private void ApplySideVelocity()
        {
            _sideVelocity *= 0.95f;
            transform.Translate(Vector3.right * _sideVelocity * Time.fixedDeltaTime);
        }
        
        private float GetAirResistance()
        {
            float heightFactor = 1 - transform.position.y / 100;

            return Mathf.Lerp(_maxAirResistance, _minAirResistance, heightFactor);
        }

        private void ApplyGravity()
        {
            float gravity = CalculateAdjustedGravity();
            _currentSpeed += Vector3.down * gravity * Time.fixedDeltaTime;
        }
        
        private float CalculateAdjustedGravity()
        {
            float heightFactor = 1 - transform.position.y / 100;
            float maxGravity = Gravity;
            float minGravity = 0.2f * Gravity;
            return Mathf.Lerp(maxGravity, minGravity, heightFactor);
        }
    }
}
