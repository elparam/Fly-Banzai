using UnityEngine;

public class AirplaneController : MonoBehaviour
{
    private bool _isFlyUp;
    private Quaternion _flyUpRotaion;
    private Quaternion _flyDownRotaion;
    public float FlyUpForce;
    public float FlyUpBorder;

    void Start()
    {
        _flyUpRotaion = new Quaternion();
        _flyUpRotaion = _flyDownRotaion = gameObject.transform.rotation;
        _flyUpRotaion.z = 20f / 180f * 3.14f;
        _flyDownRotaion.z = -10f / 180f * 3.14f; ;
    }

    void Update()
    {
        FlyUpOnMouseClick();
        StopFlyUpIfAtTop();
    }

    private void FlyUpOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isFlyUp = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isFlyUp = false;
        }
        if (_isFlyUp && IsAirplanenTop() == false)
        {
            FlyUpRotate();
            gameObject.rigidbody2D.AddForce(Vector2.up * Time.deltaTime * FlyUpForce);
        }
        else
        {
            FlyDownRotate();
        }
    }

    private void FlyUpRotate()
    {
        if (!IsAirplanenTop(0.1f))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _flyUpRotaion, Time.deltaTime * 2f);
        }
    }

    private void FlyDownRotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _flyDownRotaion, Time.deltaTime);
    }

    private bool IsAirplanenTop(float difference = 0f)
    {
        return gameObject.transform.position.y >= FlyUpBorder - difference;
    }

    private void StopFlyUpIfAtTop()
    {
        if (IsAirplanenTop() && gameObject.rigidbody2D.velocity.y > 0)
        {
            gameObject.rigidbody2D.velocity = Vector2.zero;
        }
    }
}
