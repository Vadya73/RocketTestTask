using UnityEngine;

public class AvoidCollision : MonoBehaviour
{
    public float avoidDistance = 1f;

    private void Update()
    {
        GameObject[] allObjects = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject otherObject in allObjects)
        {
            if (otherObject != gameObject)
            {
                float distance = Vector3.Distance(transform.position, otherObject.transform.position);

                if (distance < avoidDistance)
                {
                    Vector3 avoidDirection = transform.position - otherObject.transform.position;
                    transform.Translate(avoidDirection.normalized * Time.deltaTime);
                }
            }
        }
    }
}
