using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BossController))]

public class BossControllerEditor: Editor {
    const string resourceFilename = "custom-editor-uie";

    int selected = -1;

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        BossController t = (BossController)target;
        float time = 0;
        for (int i = 0; i < t.bossScript.Count; i++) {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("" + time, GUILayout.MaxWidth(20));

            t.bossScript[i] = (BossAction)EditorGUILayout.EnumPopup(t.bossScript[i]);

            if ((int)t.bossScript[i] < t.actionTimes.Length)
                time += t.actionTimes[(int)t.bossScript[i]];

            if (GUILayout.Button("-")) {
                t.bossScript.RemoveAt(i);
                i--;
                continue;
            }
            if (GUILayout.Button("+")) {
                t.bossScript.Insert(i, BossAction.Wait1);
                i--;
                continue;
            }
            if (selected == -1 && GUILayout.Button("Pick")) {
                selected = i;
            }
            if (i == selected) {
                if (selected != -1 && GUILayout.Button("Cancel")) {
                    selected = -1;
                }
            } else if (selected != -1 && GUILayout.Button("Swap")) {
                BossAction x = t.bossScript[i];
                t.bossScript[i] = t.bossScript[selected];
                t.bossScript[selected] = x;
                selected = -1;

            }
            EditorGUILayout.EndHorizontal();
        }
        if (GUILayout.Button("Add")) {
            t.bossScript.Add(BossAction.Wait1);

        }
        EditorUtility.SetDirty(target);
    }
}
