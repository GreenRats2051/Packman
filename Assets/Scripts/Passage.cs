using UnityEngine;

public class Passage : MonoBehaviour
{
    [SerializeField] private Transform connection;
    [SerializeField] private float distance;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 position = connection.position;
        position.z = other.transform.position.z;
        other.transform.position = new Vector3(position.x + distance, position.y, position.z);
    }
}