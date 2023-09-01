using System.Collections.Generic;
using System.Linq;
using CodeBase.Interfaces;
using UnityEngine;

public class ObstaclePool : MonoBehaviour, IInitializableComponent<GameObject>
{
    [SerializeField] private int _capacity;

    private Camera _camera;

    private List<GameObject> _pool = new();

    public void InitializeComponent(GameObject prefab)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            GameObject spawned = Instantiate(prefab, new Vector2(transform.position.x + 2, transform.position.y), Quaternion.identity);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        result = _pool.FirstOrDefault(p=> p.activeSelf == false);

        return result != null;
    }

    protected void DisableObjectAbroadScreen()
    {
        Vector3 disablePoint = _camera.ViewportToWorldPoint(new Vector3(-10f, -10f, 0));

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