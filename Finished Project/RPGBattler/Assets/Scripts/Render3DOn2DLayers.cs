using UnityEngine;
using System.Collections;

public class Render3DOn2DLayers : MonoBehaviour {

	public string layerName = "Foreground";
	public int layerDepth = 1;
	
	void Start () 
	{
		renderer.sortingLayerName = layerName;
		renderer.sortingOrder = layerDepth;	
	}
}
