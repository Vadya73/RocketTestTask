using CodeBase;
using CodeBase.Interfaces;
using UnityEngine;

public class InputReader : MonoBehaviour, IInitializable
{
    private RocketMover _rocketMover;
    
    public void Initialize()
    {
        _rocketMover = GetComponent<RocketMover>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) 
            _rocketMover.CanMove = true;

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) 
            _rocketMover.RotateByZ(Input.GetAxis("Horizontal"));
    }
}
