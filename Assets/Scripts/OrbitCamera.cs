using UnityEngine;
using UnityEngine.EventSystems;
public class OrbitCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    public float rotSpeed = 1.5f;
    private float _rotY;
    private float _rotX;
    public float minVert = -20.0f;
    public float maxVert = 80.0f;
    private Vector3 _offset;
    public float distance = 5f;

    void Start()
    {
        _rotY = transform.eulerAngles.y;
        _rotX = transform.eulerAngles.x;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _offset = new Vector3(0f, 0f, distance);//расстояние между камерой и игроком
    }
    void LateUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        _rotY += Input.GetAxis("Mouse X") * rotSpeed * 3; 
         _rotX -= Input.GetAxis("Mouse Y") * rotSpeed * 3;
        _rotX = Mathf.Clamp(_rotX, minVert, maxVert); //ограничиваем поворот камеры вокруг оси Х
        Quaternion rotation = Quaternion.Euler(_rotX, _rotY, 0);
        transform.position = target.position - (rotation * _offset);
        transform.LookAt(target);
    }
}
