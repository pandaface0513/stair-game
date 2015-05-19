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
		}
		
		
		private void FixedUpdate()
		{
			// Read the inputs.
			bool crouch = Input.GetKey(KeyCode.LeftControl);
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			// Pass all parameters to the character control script.
			m_Character.Move(h, crouch, m_Jump);
			m_Jump = false;
		}
	}