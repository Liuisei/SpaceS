using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    [SerializeField] float _cameraZoom = 0.5f;
    [SerializeField] float _camaraZoomMini = 5;
    [SerializeField] float _camaraZoomMax = 50;
    // Start is called before the first frame update
    void Start()
    {
        _virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_virtualCamera.m_Lens.OrthographicSize > _camaraZoomMax)
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                _virtualCamera.m_Lens.OrthographicSize -= _cameraZoom; Debug.Log("zoom-");
            }
        }
        if (_virtualCamera.m_Lens.OrthographicSize < _camaraZoomMini)
        {
            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                _virtualCamera.m_Lens.OrthographicSize += _cameraZoom; Debug.Log("zoom+");
            }
        }
    }

    private void Update()
    {


    }
}
