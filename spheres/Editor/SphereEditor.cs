using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GenerateSpheres))]
public class SphereEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector(); 

        GenerateSpheres generateSpheresScript = (GenerateSpheres)target;

        if (GUILayout.Button("Generate")) {
            generateSpheresScript.Generate();
        }
    }
}