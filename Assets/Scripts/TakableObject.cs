using UnityEngine;

public abstract class TakableObject : MonoBehaviour
{
    public void Take() => Destroy(gameObject);
}
