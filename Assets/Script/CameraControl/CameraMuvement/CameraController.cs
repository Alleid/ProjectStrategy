using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 _horizontalLimit;
    [SerializeField] private Vector2 _verticalLimit;
    [SerializeField] private float _sensitivity;
    [SerializeField] private Inversion inversion;
    [SerializeField] private float _minzoom;
    [SerializeField] private float _maxzoom;

    private Plane _plane;
    private Camera _camera;
    private Transform _transformBuffer;
    private Touch touch;

    private void Awake()
    {
        _transformBuffer = transform;
        _camera = Camera.main;
    }
    private void Update()
    {
        if (Input.touchCount == 1 )
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                _transformBuffer.position += transform.TransformDirection(DeltaPosition(touch));
                transform.position = CameraMuvement(_transformBuffer);
            }
        }
    }
    private void FixedUpdate()
    {
        if (Input.touchCount >= 1)
        {
            _plane.SetNormalAndPosition(transform.up, transform.position);
        }
        if (Input.touchCount == 2)
        {
            var pos1 = PlanePosition(Input.GetTouch(0).position);
            var pos2 = PlanePosition(Input.GetTouch(1).position);

            var pos1A = PlanePosition(Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition);
            var pos2A = PlanePosition(Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition);

            var zoom = Vector3.Distance(pos1, pos2) / Vector3.Distance(pos1A, pos2A);

            Vector3 zooms = Vector3.LerpUnclamped(pos1, _camera.transform.position, 1 / zoom);
            var q = Mathf.Clamp(zooms.y, _minzoom, _maxzoom);
            _camera.transform.position = new Vector3(transform.position.x, q, transform.position.z);
        }
    }

    private Vector3 DeltaPosition(Touch touch)
    {
        return new Vector3(
                    touch.deltaPosition.x * _sensitivity * (float)inversion,
                    transform.position.y,
                    touch.deltaPosition.y * _sensitivity * (float)inversion
                    ) * Time.deltaTime;
    }
    private Vector3 CameraMuvement (Transform transform)
    {
        return new Vector3(
                    Mathf.Clamp(transform.position.x, _verticalLimit.x, _verticalLimit.y),
                    _transformBuffer.position.y,
                    Mathf.Clamp(transform.position.z, _horizontalLimit.x, _horizontalLimit.y));
    }
    private Vector3 PlanePosition(Vector2 screenPos)
    {
        var rayNow = _camera.ScreenPointToRay(screenPos);
        if (_plane.Raycast(rayNow, out var enterNow))
        {
            return rayNow.GetPoint(enterNow);
        }
        return Vector3.zero;
    }
}