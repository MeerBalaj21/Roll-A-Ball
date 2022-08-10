using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody), typeof(SphereCollider))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private Rigidbody rb;
	[SerializeField] private FloatingJoystick fj;
	//[SerializeField] private float moveSpeed;

	public GameObject speedText;
	public GameObject sizeText;
	public GameObject winTextObject;
	public GameObject failTextObject;
	public GameObject WinObject;
	public GameObject Star1;
	public GameObject Star2;
	public GameObject Star3;
	
	public AudioClip powerUpSpeed;
	public AudioClip powerUpSize;
	public AudioClip StarSound;
	public AudioClip winSound;
	public AudioClip failSound;
	public AudioSource _audioSource;
	public float speed;
	private int count;
	private float timerSpeed;
	private float timerSize;
	//private float timerEnd;
	//private float timerJump;
	//private float movementY;
	//private float movementX;
	private Vector3 OGScale;
	//private float someValue;



	void Start()
	{
		rb = GetComponent<Rigidbody>();
		timerSpeed = 0.0f;
		timerSize = 0.0f;
		//timerEnd = 0.0f;
		//timerJump = 0.0f;
		speed = 6f;
		count = 0;
		//someValue = 15.0f;
		OGScale = transform.localScale;
		Star1.SetActive(false);
		Star2.SetActive(false);
		Star3.SetActive(false);
		winTextObject.SetActive(false);
		failTextObject.SetActive(false);
	}

	void FixedUpdate()
	{
		//Vector3 movement = new Vector3(movementX, 0.0f, movementY);
		//rb.AddForce(movement * speed);
		rb.velocity = new Vector3(fj.Horizontal * speed, rb.velocity.y, fj.Vertical * speed);

		if (timerSpeed > 0.0f)
        {
			timerSpeed = timerSpeed - Time.deltaTime;
        }
        else
        {
			speed = 6f;
			speedText.SetActive(false);
        }
		if (timerSize > 0.0f)
		{
			timerSize = timerSize - Time.deltaTime;
		}
		else
		{
			transform.localScale = OGScale;
			sizeText.SetActive(false);
		}
        //if (timerEnd > 0.0f)
        //{
        //	timerEnd = timerEnd - Time.deltaTime;
        //}
        //else
        //      {
        
        //}
    }

    private void playSize()
    {
		_audioSource.clip = powerUpSize;
		_audioSource.Play();
    }
	private void playSpeed()
	{
		_audioSource.clip = powerUpSpeed;
		_audioSource.Play();
	}
	private void playStarSound()
	{
		_audioSource.clip = StarSound;
		_audioSource.Play();
	}
	private void playWinSound()
	{
		_audioSource.clip = winSound;
		_audioSource.Play();
	}
	private void playFailSound()
	{
		_audioSource.clip = failSound;
		_audioSource.Play();
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("PickUp"))
		{
			other.gameObject.SetActive(false);
			count = count + 1;
			if(count == 1)
            {
				Star1.SetActive(true);
            }
			if (count == 2)
			{
				Star2.SetActive(true);
			}
			if (count == 3)
			{
				Star3.SetActive(true);
			}
			playStarSound();
		}
		if (other.gameObject.CompareTag("SpeedUp"))
		{
			other.gameObject.SetActive(false);
			timerSpeed = 10f;
			speed = speed + 2f;
			speedText.SetActive(true);
			playSpeed();
		}
		if (other.gameObject.CompareTag("SizeUp"))
		{
			other.gameObject.SetActive(false);
			timerSize = 10f;
			timerSpeed = 10f;
			speed = speed - 3f;
			transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			sizeText.SetActive(true);
			playSize();
		}
		if(other.gameObject.CompareTag("Win"))
        {
			if (count >= 1 && count <= 3)
			{
				Debug.Log("win condition working");
				// Set the text value of your 'winText'
				winTextObject.SetActive(true);
				playWinSound();
			}

		}
		if(other.gameObject.CompareTag("fail"))
        {
			failTextObject.SetActive(true);
			playFailSound();
			//timerEnd = 10f;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
		}
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
			gameObject.SetActive(false);
        }
        
    }
 //   void OnMove(InputValue value)
	//{
	//	Vector2 v = value.Get<Vector2>();

	//	movementX = v.x;
	//	movementY = v.y;
	//}
	
}
