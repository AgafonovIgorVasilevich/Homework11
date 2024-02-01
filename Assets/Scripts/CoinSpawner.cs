using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Coin[] _coinPrototypes;
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
        Coin coin;

        while (_count > 0)
        {
            spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            if (spawnPoint.childCount > 0)
                continue;

            coin = _coinPrototypes[Random.Range(0, _coinPrototypes.Length)];
            Instantiate(coin, spawnPoint);
            _count--;
        }
    }
}