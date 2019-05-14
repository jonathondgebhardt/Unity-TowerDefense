using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float fuzzyLocationTolerance = 0.4f;

    private Transform target;
    private int currentWaypoint = 0;

    void Start()
    {
        target = Waypoints.waypoints[currentWaypoint];
    }

    void Update()
    {
        // Move towards the next waypoint.
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * movementSpeed * Time.deltaTime, Space.World);

        // Update next waypoint if we've reached current waypoint.
        if(Vector3.Distance(transform.position, target.position) <= fuzzyLocationTolerance)
        {
            UpdateWaypointIndex();
        }
    }

    void UpdateWaypointIndex()
    {
        // Keep getting next waypoint until there are no more. 
        if(++currentWaypoint < Waypoints.waypoints.Length)
        {
            target = Waypoints.waypoints[currentWaypoint];
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
