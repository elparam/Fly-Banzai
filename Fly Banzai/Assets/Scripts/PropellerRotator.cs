using UnityEngine;

public class PropellerRotator : MonoBehaviour
{
    public float Speed;

	void Start () {
	
	}
	
	void Update () {
        transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * Speed);
	}
}
