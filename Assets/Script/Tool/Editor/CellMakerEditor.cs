﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CellMaker))]
public class CellMakerEditor : Editor {

    CellMaker cellMaker;
    void OnEnable()
    {
        cellMaker = (CellMaker)target;
    }

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();

        var splitLevel =cellMaker.GetMaxSplitLeve();
        var columnCount = Mathf.Pow(2, splitLevel);
        GUILayout.Label("if not using quad tree:" + Mathf.Pow(columnCount, 2));

        var OuterQuadRectCount = cellMaker.GetOuterQuadRect().Count;
        GUILayout.Label("OuterQuadRectCount:"+OuterQuadRectCount);

        var InnerQuadRectCount = cellMaker.GetInnerQuadRect().Count;
        GUILayout.Label("InnerQuadRectCount:" + InnerQuadRectCount);

        if (GUILayout.Button("Get All BoxCollider & Generate QuadTree"))
        {
            cellMaker.GetAllBoxColliderMetaInfoInSceneAndGenerateRect();

            cellMaker.GenerateQuadTreeConnectedNode();
            cellMaker.MakeConnected();

            cellMaker.CollectOuterQuadRect();
            cellMaker.CollectInnerQuadRect();

            SceneView.RepaintAll();
            Debug.Log("Generate");
        }

        if (GUILayout.Button("TestIsIntersect"))
        {
            cellMaker.TestIsIntersect();
        }
    }
}
