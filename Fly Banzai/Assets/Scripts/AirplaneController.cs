using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    private bool _isFly = false;
    Quaternion FlyUpRotaion = new Quaternion(0f,0f,0.1f,0f);

    void Start()
    {

    }

    void Update()
    {
        FlyUp();
    }

    private void FlyUp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isFly = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isFly = false;
        }
        if (_isFly)
        {
            RotateAirplaneBody();
            gameObject.rigidbody2D.AddForce(Vector2.up*Time.deltaTime*50);
        }
    }

    private void RotateAirplaneBody()
    {
        //transform.rotation = Quaternion.Lerp(transform.rotation, FlyUpRotaion, Time.deltaTime*10);
    }
}
