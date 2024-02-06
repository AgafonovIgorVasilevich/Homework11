using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(Health))]

public class Player : MonoBehaviour
{
    [SerializeField] private VampireArea _vampireArea;

    private PlayerMovement _movement;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.W) && _vampireArea.isActiveAndEnabled == false)
            _vampireArea.gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Enemy enemy))
        {
            Vector3 directon = transform.position - enemy.transform.position;
            directon.y = 1;
            _movement.FlyOff(directon);
        }
    }
}