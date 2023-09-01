using CodeBase.Interfaces;
using UnityEngine;

namespace CodeBase.Obstacles
{
    public class ObstacleGenerator : ObstaclePool, IInitializable
    {
        [SerializeField] private GameObject _obstaclePrefab;

        [SerializeField] private float _minSpawnPositionX, _maxSpawnPositionX;
        [SerializeField] private float _minSpawnPositionY, _maxSpawnPositionY;
        [SerializeField] private float _spawnRate;

        [SerializeField] private Transform _target;

        private float _elapsedTime = 0;

        public void Initialize()
        {
            InitializeComponent(_obstaclePrefab);
        }

        private void Update()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime > _spawnRate)
            {
                if (TryGetObject(out GameObject obstacle))
                {
                    _elapsedTime = 0;

                    float spawnPositionX = Random.Range(_minSpawnPositionX,_maxSpawnPositionX);
                    float spawnPositionY = Random.Range(_minSpawnPositionY,_maxSpawnPositionY);
                    Vector3 spawnPoint = new Vector3(spawnPositionX, spawnPositionY, _target.position.z);
                    obstacle.SetActive(true);
                    obstacle.transform.position = spawnPoint + _target.position;

                    DisableObjectAbroadScreen();
                }
            }
        }
    }
}