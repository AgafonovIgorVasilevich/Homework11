using UnityEngine;
using System.Linq;

public class Eye : MonoBehaviour
{
    [SerializeField] private float _distanceToTarget = 10;
    [SerializeField] private float _distanceToGround = 1;

    private Vector3 _direction = Vector3.left;
    private RaycastHit2D[] _targets;
    private int _countTargets;

    public Vector3 Direction => _direction;

    public bool IsSeeGround() => Physics2D.Raycast(transform.position, Vector3.down, _distanceToGround);

    public bool IsSeeTarget()
    {
        _targets = Physics2D.RaycastAll(transform.position, _direction, _distanceToTarget);

        if (_targets.Length == 0)
            return false;

        _countTargets = _targets.Count(hit => hit.collider.GetComponent<Player>() != null);

        return _countTargets > 0;
    }

    public void Rotate()
    {
        transform.localPosition = Vector2.Reflect(transform.localPosition, Vector2.right);
        _direction *= -1;
    }
}