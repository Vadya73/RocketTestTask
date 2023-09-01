using CodeBase.Interfaces;
using UnityEngine;

namespace CodeBase.Obstacles
{
    public class Obstacle : MonoBehaviour
    {
        [SerializeField] private int _damage;
        
        private const string PlayerTag = "Player";
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(PlayerTag))
            {
                other.gameObject.GetComponent<IDamagable>().ApplyDamage(_damage);
            }
            Debug.Log("Collision");
        }
    }
}