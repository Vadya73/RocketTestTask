using CodeBase.Interfaces;
using UnityEngine;

namespace CodeBase.Obstacles
{
    public class Obstacle : MonoBehaviour,IInitializable
    {
        [SerializeField] private float collisionDistance = 1.0f;
        [SerializeField] private int _damage;
        
        private Rocket _rocket;
        private const string PlayerTag = "Player";
        private bool _isInit;
        
        public void Initialize()
        {
            _rocket =  GameObject.FindWithTag(PlayerTag).GetComponent<Rocket>();
        }
        
        private void Update()
        {
            float distance = Vector3.Distance(_rocket.transform.position, transform.position);

            if (distance < collisionDistance)
            {
                _rocket.ApplyDamage(_damage);
                gameObject.SetActive(false);
            }
        }
    }
}