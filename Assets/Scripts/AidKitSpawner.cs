using UnityEngine;

public class AidKitSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private AidKit _aidKitPrototype;
    [SerializeField] private int _count;

    private void OnValidate()
    {
        if(_count > _spawnPoints.Length)
            _count = _spawnPoints.Length;
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        Transform spawnPoint;

        while(_count > 0)
        {
            spawnPoint = _spawnPoints[Random.Range(0,
                _spawnPoints.Length)];

            if(spawnPoint.childCount > 0)
                continue;

            Instantiate(_aidKitPrototype, spawnPoint);
            _count--;
        }
    }
}