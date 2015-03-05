using UnityEngine;
using UnityEngine.UI;

public class AirplaneController : MonoBehaviour
{
    private bool _isFlyUp;
    private Quaternion _flyUpRotaion;
    private Quaternion _flyDownRotaion;
    public float FlyUpForce;
    public float FlyUpBorder;
    public Rigidbody2D _rigidbody;

    private Text _gameOverText;
    private bool _isGameOver;

    void Start()
    {
        _flyUpRotaion = new Quaternion();
        _flyUpRotaion = _flyDownRotaion = gameObject.transform.rotation;
        _flyUpRotaion.z = 20f / 180f * 3.14f;
        _flyDownRotaion.z = -10f / 180f * 3.14f;
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameOverText = GameObject.FindGameObjectWithTag("GameOverText").GetComponent<Text>();
        _gameOverText.enabled = false;
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
            _rigidbody.AddForce(Vector2.up * Time.deltaTime * FlyUpForce);
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

    private bool IsAirplanenDown(float difference = 0f)
    {
        return gameObject.transform.position.y <= - FlyUpBorder - difference;
    }

    private void StopFlyUpIfAtTop()
    {
        if (IsAirplanenTop() && _rigidbody.velocity.y > 0)  
        {
            _rigidbody.velocity = Vector2.zero;
        }
        if (IsAirplanenDown() && _rigidbody.velocity.y < 0)
        {
            _gameOverText.enabled = true;
        }
    }
}
