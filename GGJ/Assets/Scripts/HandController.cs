using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class HandController : MonoBehaviour {
    
    private bool isGrabbing = false;
    private IGrabbable currentlyGrabbed = null;

    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform grabbingTransform;
    public Transform GrabbingTransform => grabbingTransform;
    
    private Rigidbody rigidbody;
    
    [SerializeField]
    private float Thrust = 1.0f;
    [SerializeField]
    private float GrabDistance = 1.0f;
    
    [SerializeField]
    private KeyCode UpKeyCode;
    [SerializeField]
    private KeyCode LeftKeyCode;
    [SerializeField]
    private KeyCode RightKeyCode;
    [SerializeField]
    private KeyCode DownKeyCode;
    [SerializeField]
    private KeyCode ForwardKeyCode;
    [SerializeField] 
    private KeyCode BackwardKeyCode;
    [SerializeField]
    private KeyCode GrabKeyCode;

    private void Grab() {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.forward,out hit,GrabDistance)) {
            Debug.DrawRay(transform.position,Vector3.forward * hit.distance,Color.yellow);
            Debug.Log(hit.ToString());
            
            GameObject grabbedGameObject = hit.transform.gameObject;
            IGrabbable grabbable = grabbedGameObject.GetComponent<IGrabbable>();
            if (grabbable != null) {
                animator.SetBool("grab", true);
                grabbable.Grab(this);
                isGrabbing = true;
                currentlyGrabbed = grabbable;
            }
        }
        else {
            Debug.DrawRay(transform.position,Vector3.forward * GrabDistance,Color.yellow);
        }
    }
    
    // Start is called before the first frame update
    public void Start() {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        if (Input.GetKey(UpKeyCode)) {
            rigidbody.AddForce(Vector3.up * Thrust);
        }
        if (Input.GetKey(RightKeyCode)) {
            rigidbody.AddForce(Vector3.right * Thrust);
        }
        if (Input.GetKey(DownKeyCode)) {
            rigidbody.AddForce(Vector3.down * Thrust);
        }
        if (Input.GetKey(LeftKeyCode)) {
            rigidbody.AddForce(Vector3.left * Thrust);
        }
                
        if (Input.GetKey(ForwardKeyCode)) {
            rigidbody.AddForce(Vector3.forward * Thrust);
        }
        if (Input.GetKey(BackwardKeyCode)) {
            rigidbody.AddForce(Vector3.back * Thrust);
        }

        if (Input.GetKeyDown(GrabKeyCode)) {
            if (isGrabbing) {
                currentlyGrabbed.Release();
                isGrabbing = false;
                currentlyGrabbed = null;
                animator.SetBool("grab", false);
            }
            else {
                Grab();
            }
            
        }
    }
}
