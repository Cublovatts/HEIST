using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

[CustomEditor(typeof(NavMeshAgent))]
public class NavMeshAgentPathVisualizer : Editor
{
    private const float DotSize = 0.2f;
    private const float DotSpacing = 0.5f;

    private void OnSceneGUI()
    {
        NavMeshAgent agent = (NavMeshAgent)target;
        if (agent == null || agent.path == null || agent.path.corners.Length < 2)
            return;

        Handles.color = Color.green;
        for (int i = 0; i < agent.path.corners.Length - 1; i++)
        {
            Handles.DrawDottedLine(agent.path.corners[i], agent.path.corners[i + 1], DotSpacing);
            Handles.SphereHandleCap(0, agent.path.corners[i], Quaternion.identity, DotSize, EventType.Repaint);
        }

        Handles.SphereHandleCap(0, agent.path.corners[agent.path.corners.Length - 1], Quaternion.identity, DotSize, EventType.Repaint);
    }
}
