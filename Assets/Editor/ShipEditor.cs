using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Ship))]
public class ShipEditor : Editor {
    Ship myShip;
    int selection = 0;
    string[] selectionsToMake = { "Ship", "Crew" };

    void OnEnable()
    {
        myShip = (Ship)target;
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //base.OnInspectorGUI();
        //set center alignment for main segment labels
        GUIStyle centerer = GUI.skin.label;
        centerer.alignment = TextAnchor.MiddleCenter;

        //setting a guicontent for tooltips
        GUIContent tip = new GUIContent();

        selection = GUILayout.SelectionGrid(selection, selectionsToMake, 2);

        if (selection == 0)
        {
            EditorGUILayout.BeginVertical("Box");
            tip.text = "Hit Points";
            myShip.hitPoints = EditorGUILayout.IntField(tip, Mathf.Max(1, myShip.hitPoints));
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(10);
            tip.text = "Ship Guns";
            SerializedProperty guns = serializedObject.FindProperty("shipGuns");
            EditorGUILayout.PropertyField(guns, tip, true);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
            

            EditorGUILayout.BeginVertical("Box");
            tip.text = "Armor";
            myShip.armor = EditorGUILayout.IntSlider(tip, myShip.armor, 10, Mathf.Min(100 - myShip.attack - myShip.agility, 80));
            tip.text = "Attack";
            myShip.attack = EditorGUILayout.IntSlider(tip, myShip.attack, 10, Mathf.Min(100 - myShip.armor - myShip.agility, 80));
            tip.text = "Agility";
            myShip.agility = EditorGUILayout.IntSlider(tip, myShip.agility, 10, Mathf.Min(100 - myShip.attack - myShip.armor, 80));
            EditorGUILayout.EndVertical();
        }
        else if(selection == 1)
        {
            EditorGUILayout.BeginVertical("Box");
            EditorGUILayout.BeginHorizontal();
            GUILayout.Space(10);
            tip.text = "Crew";
            SerializedProperty crew = serializedObject.FindProperty("crewMembers");
            EditorGUILayout.PropertyField(crew, tip, true);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();
        }

        serializedObject.ApplyModifiedProperties();
    }

}

//public class CrewMember
//{

//    public enum Style { Aggresive, Defensive, Evasive };

//    public string crewName;
//    public int def, str, agi, health;
//    public Style fightStyle;
//}


//public class Ship : MonoBehaviour
//{
//    public enum GunStyle { cannon, plasma, machinegun, flamethrower };


//    /*
//     * Armor, attack and agility all share a pool of 100 points.
//     * Each stat cant go below 10. So Atk = 10, Arm = 10, Agi = 10,
//     * The rest of the point (70). Can be divided out.
//     * Make sure they never exceed a total of 100 points.
//     * The user can use less than the 100, just make sure they cant below the 10 for each.
//     */
//    public int armor, attack, agility;
//    public int hitPoints;
//    public GunStyle[] shipGuns;
//    public CrewMember[] crewMembers;

//}
