using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyCharacterController : MonoBehaviour 
{
	public int maxPoints;
	public float Velocity;
	public float Jump;
	public Text textPoints;
	public GameObject panelWinner;
	public AudioClip coinsound;

	private Rigidbody rb;
	private int Points;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		Points = 0;
		SetCountText ();
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveUp = Input.GetAxis("Jump");

		Vector3 movement = new Vector3 (moveHorizontal, moveUp, moveVertical);

		rb.AddForce (movement * Velocity);
		rb.AddForce (movement * Jump);
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Points"))
		{
			AudioSource.PlayClipAtPoint(coinsound, transform.position, 0.5f);
			
			other.gameObject.SetActive (false);
			Points = Points + 1;
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		textPoints.text = Points.ToString() + " / " + maxPoints.ToString();
		if (Points >= maxPoints)
		{
			panelWinner.SetActive(true);
		}
	}
}
