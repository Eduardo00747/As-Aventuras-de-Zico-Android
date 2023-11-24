using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public List<Transform> recentWaypoints = new List<Transform>();
    public int maxWaypointsToRecord = 3;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("WaypointLilas") || other.CompareTag("WaypointVerde"))
        {
            Transform waypoint = other.transform;

            // Verifique se o waypoint n�o est� na lista antes de adicion�-lo
            if (!recentWaypoints.Contains(waypoint))
            {
                // Adicione o novo waypoint � lista de recentWaypoints
                recentWaypoints.Insert(0, waypoint);

                // Se a lista tiver mais waypoints do que o m�ximo permitido, remova os extras
                while (recentWaypoints.Count > maxWaypointsToRecord)
                {
                    recentWaypoints.RemoveAt(recentWaypoints.Count - 1);
                }
            }
        }
    }
}
