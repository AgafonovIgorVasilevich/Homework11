using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject _template;
    [SerializeField] private int _count;

    private void OnValidate()
    {
        if (_count > _spawnPoints.Length)
            _count = _spawnPoints.Length;
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Transform spawnPoint;

        while (_count > 0)
        {
            spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            if (spawnPoint.childCount > 0)
                continue;

            Instantiate(_template, spawnPoint);
            _count--;
        }
    }
}