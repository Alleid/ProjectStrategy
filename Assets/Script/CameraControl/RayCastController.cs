using UnityEngine;

public class RayCastController : MonoBehaviour
{
    private Camera _camera;
    private RaycastHit _hit;
    bool switchTouch = true;

    private void Awake()
    {
        _camera = Camera.main;
    }
    private void FixedUpdate()
    {
        if (Input.touchCount == 1 && switchTouch)
        {
            switchTouch = false;
            Ray ray = _camera.ScreenPointToRay(Input.GetTouch(0).position);
            if (Physics.Raycast(ray, out _hit))
            {
                var _objectHit = _hit.transform.gameObject;
                if(_objectHit.TryGetComponent<IBuff>(out IBuff buff))
                {
                    EventManagerStat.OnBuffStat(buff);
                }
            }
        }else if(Input.touchCount == 0) 
            switchTouch = true;
    }
}
