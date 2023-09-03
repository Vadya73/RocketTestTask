using System.Collections.Generic;
using System.Linq;
using CodeBase.Interfaces;
using CodeBase.Obstacles;
using UnityEngine;
using IInitializable = Unity.VisualScripting.IInitializable;

public class ObstaclePool : MonoBehaviour, IInitializableComponent<GameObject>
{
    [SerializeField] private int _capacity;

    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    public void InitializeComponent(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, new Vector2(transform.position.x + 2, transform.position.y), Quaternion.identity);
            spawned.SetActive(false);
            spawned.GetComponent<Obstacle>().Initialize();

            _pool.Add(spawned);
        }
    }
    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p=> p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector2(0, -7f));

        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.x < disablePoint.x)
                {
                    item.SetActive(false);
                }
            }
        }
    }
}