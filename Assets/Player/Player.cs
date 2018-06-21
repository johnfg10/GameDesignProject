 using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
	private CharacterController _characterController;
	
	public Camera camera;
	public Gun gun; 
	
	public KeyCode MoveForwardKey = KeyCode.W;
	public KeyCode MoveBackwardKey = KeyCode.S;
	public KeyCode MoveLeftKey = KeyCode.A;
	public KeyCode MoveRightKey = KeyCode.D;
	public KeyCode MoveJumpKey = KeyCode.Space;
	public KeyCode InteractKey = KeyCode.E;
	public KeyCode RunKey = KeyCode.LeftShift;
	
	public int MovementSpeed = 0;
	public int JumpHeight = 10;
	public int TurnSpeed = 90;
	public float Gravity = 9.8F;

	private float RunSpeed;
	private float vSpeed = 0;
	private Vector3 mousePos = Vector3.zero;
	
	private float yaw = 0.0f;
	private float pitch = 0.0f;
	
	public static int firecount = 0;

	private static bool hasLoaded = false;
	private static bool hasWon = false;
	private static bool hasLosted = false;
	
	// Use this for initialization
	void Start ()
	{
		_characterController = GetComponent<CharacterController>();
		gun = gameObject.AddComponent<Gun>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//_characterController.SimpleMove(Vector3.zero);
	}
	
	

		private void FixedUpdate()
		{
			yaw += TurnSpeed * Input.GetAxis("Mouse X");
			pitch -= TurnSpeed * Input.GetAxis("Mouse Y");
			camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
			transform.eulerAngles = new Vector3(0, yaw, 0.0f);
			var movement = transform.forward * Input.GetAxis("Vertical") * MovementSpeed;
			if (_characterController.isGrounded)	
			{
				vSpeed = 0;
				if (Input.GetKey(RunKey))
				{
					RunSpeed = 1.1F;
				}
				if (Input.GetKey(MoveForwardKey))
				{
					movement += (transform.forward * MovementSpeed * RunSpeed);
				}
				if (Input.GetKey(MoveBackwardKey))
				{
					movement += (transform.InverseTransformDirection(Vector3.back) * MovementSpeed);
				}
				if (Input.GetKey(MoveLeftKey))
				{
					movement += transform.TransformDirection(Vector3.left) * MovementSpeed;
				}
				if (Input.GetKey(MoveRightKey))
				{
					movement += transform.TransformDirection(Vector3.right) * MovementSpeed;
				}
				if (Input.GetKey(MoveJumpKey))
				{
					vSpeed = JumpHeight;
				}
			}
			if (Input.GetMouseButtonDown(0))
			{
				firecount++;
				gun.Fire();
			}
			if (Input.GetKeyDown(InteractKey))
			{
				RaycastHit hit;
				Vector3 fwd = transform.TransformDirection(Vector3.forward);
				if (Physics.Raycast(transform.position, fwd, out hit, 50))
				{
					var hitObj = hit.transform.gameObject;
					var interactable = hitObj.GetComponent<IInteractable>();
					if (interactable != null)
					{
						interactable.Interact(gameObject);
					}
				}
			}
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
			if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha2))
			{
				SceneManager.LoadScene("test");
			}
			if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Alpha1))
			{
				SceneManager.LoadScene("SceneTwo");
			}
			vSpeed -= Gravity * Time.deltaTime;
			movement.y = vSpeed;
			_characterController.Move(movement * Time.deltaTime);
			if (EnemyAi.Killed >= 3 && hasLoaded == false)
			{
				SceneManager.LoadScene("SceneTwo");
				hasLoaded = true;
			}else if (EnemyAi.Killed >= 6 && hasWon == false)
			{
				print("winner!");
				SceneManager.LoadScene("WinScene");
				hasWon = true;
			}
	
			if (Time.realtimeSinceStartup >= 60 && hasLosted == false)
			{
				SceneManager.LoadScene("LoseScene");
				print("Game failed score is: " + EnemyAi.Killed);
				Application.Quit();
				hasLosted = true;
			}
		}

/*	private void OnCollisionEnter(Collision other)(
	{
		Debug.Log(other.GetType());
	}*/
}
