using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {

	// x,y方向にオブジェクトを生成する上限
	public GameObject child;
	public int num_x_max = 20;
	public int num_z_max = 20;



	// Use this for initialization
	void Start () {
		
		
	}
	
	void CreateObject() {

		// x軸に沿ってオブジェクト生成
		for (int i = 0; i <= num_x_max; i++) {
			Instantiate (child, new Vector3 (i, 0, 0), Quaternion.identity);
			Instantiate(child, new Vector3(i, 0, num_z_max), Quaternion.identity);
		}

		// z軸に沿ってオブジェクト生成
		for (int j = 0; j <= num_x_max; j++) {
			Instantiate (child, new Vector3 (0, 0, j), Quaternion.identity);
			Instantiate(child, new Vector3(num_x_max, 0, j), Quaternion.identity);
		}
	}
}
