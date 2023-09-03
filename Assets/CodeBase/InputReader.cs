using CodeBase;
using CodeBase.Interfaces;
using UnityEngine;

public class InputReader : MonoBehaviour, IInitializable
{
    [SerializeField] private RocketMover _rocketMover;

    private float _rotateValue;
    private bool _canMove;
    private const string Player = "Player";
    
    public void Initialize()
    {
        if (_rocketMover == null)
            _rocketMover = GameObject.FindWithTag(Player).GetComponent<RocketMover>();
    }

    private void Update()
    {
        if (_rotateValue != 0)
            TryRotate(_rotateValue);

        if (_canMove)
            TryMove(_canMove);
    }

    public void TryMove(bool value)
    {
        _canMove = value;
        _rocketMover.CanMove = _canMove;
    }

    public void TryRotate(float value)
    {
        _rotateValue = value;
        _rocketMover.RotateByZ(_rotateValue);
    }
}
