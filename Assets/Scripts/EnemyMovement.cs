using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyAnimator))]

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private Way _way;

    private EnemyAnimator _animator;

    private void Start()
    {
        _animator = GetComponent<EnemyAnimator>();
        StartCoroutine(Patrol(_way.GetWayPoints()));
    }

    private IEnumerator Patrol(Vector3[] wayPoints)
    {
        WaitForSeconds delay = new WaitForSeconds(1);
        bool isPatrol = wayPoints.Length > 0;
        int currentPoint = 0;

        if(isPatrol)
        {
            _animator.LookAt(wayPoints[currentPoint]);
            _animator.Run();
        }

        while (isPatrol)
        {
            if (transform.position == wayPoints[currentPoint])
            {
                _animator.Stay();
                currentPoint = (currentPoint + 1) % wayPoints.Length;
                yield return delay;
                _animator.LookAt(wayPoints[currentPoint]);
                _animator.Run();
            }

            transform.position = Vector3.MoveTowards(transform.position, wayPoints[currentPoint], _speed * Time.deltaTime);

            yield return null;
        }
    }
}
