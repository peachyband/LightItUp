using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCtrl2D : MonoBehaviour
{
	[Range (0,1f)] public float m_MovementSmoothing = 0.5f;
	public Rigidbody2D m_Rigidbody2D;
	private Vector3 m_Velocity = Vector3.zero;

	public void Move(float move)
	{
		// Move the character by finding the target velocity
		Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
		// And then smoothing it out and applying it to the character
		m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
	}
}
