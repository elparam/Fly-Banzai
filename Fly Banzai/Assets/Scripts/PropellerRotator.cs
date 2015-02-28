using UnityEngine;
using System.Collections;

public class PropellerRotator : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        transform.Rotate(new Vector3(0,0, -1) * Time.deltaTime * 1000);
	}
}
