using UnityEngine;
using System.Linq;

public class Way : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;

    public Vector3[] GetWayPoints()
    {
        return _wayPoints.Select(wayPoint => wayPoint.position).ToArray();
    }
}