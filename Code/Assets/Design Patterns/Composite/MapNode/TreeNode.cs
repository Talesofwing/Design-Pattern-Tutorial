﻿using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Leaf
/// </summary>
public class TreeNode : MapNode {
    
    public override void AddChild (MapNode node) { }
    
    public override void RemoveChild (MapNode node) { }
    
    public override void Display () {
        Debug.Log ("Tree節點");
    }
    
#region Iterator & Composite

    public override IEnumerator<MapNode> CreateIterator () {
        return new NULLIterator ();
    }

#endregion
    
}