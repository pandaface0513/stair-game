using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

	[RequireComponent(typeof (Player2D))]
	public class Player2DUserControl : MonoBehaviour
	{
		private Player2D m_Character;
		private bool m_Jump;
		
		
		private void Awake()
		{
			m_Character = GetComponent<Player2D>();
		}
		
		
		private void Update()
		{
			if (!m_Jump)
			{
				// Read the jump input in Update so button presses aren't missed.
				m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
			}
		//check if player fell through
		Debug.Log("Character Y" + m_Character.transform.position.y);
		}
		
		
		private void FixedUpdate()
		{
			//check if using a computer
			if (SystemInfo.deviceType == DeviceType.Desktop) {
				// Read the inputs.
				//bool crouch = Input.GetKey (KeyCode.LeftControl);
				float h = CrossPlatformInputManager.GetAxis ("Horizontal");
				// Pass all parameters to the character control script.
				m_Character.Move (h, false, m_Jump);
				m_Jump = false;
			} else {
				//use accelerometer
				float moveHorizontal = Input.acceleration.x;
				m_Character.Move(moveHorizontal, false, m_Jump);
			}
		}
	}
