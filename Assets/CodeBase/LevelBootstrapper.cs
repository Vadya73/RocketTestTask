using CodeBase.Interfaces;
using CodeBase.Obstacles;
using UnityEngine;

namespace CodeBase
{
    public class LevelBootstrapper : MonoBehaviour
    {
        [SerializeField] private Rocket _rocket;
        [SerializeField] private ObstacleGenerator _obstacleGenerator;
        private void Awake()
        {
            var creatureInits = _rocket.GetComponents<IInitializable>();
            foreach (var component in creatureInits)
            {
                component.Initialize();
            }
            
            _obstacleGenerator.GetComponent<ObstacleGenerator>().Initialize();
        }
    }
}