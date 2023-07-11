using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(PatrolSequence))]
public class PatrolSequenceEditor : Editor
{
    private void OnSceneGUI()
    {
        PatrolSequence patrolSequence = (PatrolSequence)target;
        Handles.color = new Color(Color.yellow.r, Color.yellow.g, Color.yellow.b, 0.1f);
        Handles.DrawSolidDisc(patrolSequence.Destinations[patrolSequence.GetCurrentDestinationIndex()].Destination.position, Vector3.up, 1.0f);
    }
}
