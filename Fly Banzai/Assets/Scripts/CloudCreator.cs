using UnityEngine;

public class CloudCreator : MonoBehaviour
{
    public GameObject Cloud;
    public float Distance;
    private GameObject _lastCloud;

    void Start() { }

    void Update()
    {
        if (IsTimeToCreate())
        {
            CreateCloud();
        }
    }

    private void CreateCloud()
    {
        var intantiatePosition = transform.position;
        intantiatePosition.z = intantiatePosition.z + Random.Range(-0.1f, 0.2f);
        var createdObject = Instantiate(Cloud, intantiatePosition, Quaternion.identity);
       
        _lastCloud = createdObject as GameObject;
        _lastCloud.transform.parent = this.gameObject.transform;
    }

    private bool IsTimeToCreate()
    {
        var isThisIsFirstCloud = _lastCloud == null;
        var currentDistance = _lastCloud != null ? _lastCloud.transform.position.x -
            transform.position.x : 0f;
        var isDistanceToCreateCloud = Mathf.Abs(currentDistance) >= Distance;
        return isThisIsFirstCloud || isDistanceToCreateCloud;
    }
}
