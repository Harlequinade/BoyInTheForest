using UnityEngine.EventSystems;
using UnityEngine;

public class CharacterMovementControl : MonoBehaviour {

    public Animator anim;
    private Rigidbody rig;
    public Transform main_cam;                  
    private Vector3 main_camForward;                               
    private Vector3 move;
    public float move_speed = 10f;
    public float rotation_speed = 1f;
    private float AnimatorSpeed;

    void Start () {
        rig = GetComponent<Rigidbody>();
        rig.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
        anim = GetComponent<Animator>();
    }


    void Update () {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        AnimatorSpeed = 0;
        move = Vector3.zero;
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        main_camForward = Vector3.Scale(main_cam.forward, new Vector3(1, 0, 1)).normalized;
        move.Set(h * move_speed, 0f, v * move_speed);
        move = Vector3.ClampMagnitude(move, move_speed);
        if (Input.GetMouseButtonDown(0))
            anim.SetTrigger("Kick");
        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("jump");
        }
        if (h != 0 || v != 0)
        {
            AnimatorSpeed = 2;
            Turning();
            if (Input.GetKey(KeyCode.LeftShift))
                AnimatorSpeed = 3;
        }
        anim.SetFloat("speed", AnimatorSpeed);

    }

    void Turning()
    {
        Quaternion temp = main_cam.rotation;
        main_cam.eulerAngles = new Vector3(0, main_cam.eulerAngles.y, 0);
        move = main_cam.TransformDirection(move);
        main_cam.rotation = temp;
        Quaternion direction = Quaternion.LookRotation(move);
        transform.rotation = Quaternion.Lerp(transform.rotation, direction, rotation_speed * Time.deltaTime);
    }
}
