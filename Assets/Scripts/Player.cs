using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class Player : MonoBehaviour  //TODO Rename to "PlayerController"
{
	[Header("General")]
	[Tooltip("Speed in m*s^-1")][SerializeField] float Speed = 20f;
	[Tooltip("in m")] [SerializeField] float XRange = 5f;
	[Tooltip("in m")] [SerializeField] float YRange = 3f;
	[Header("Pitch Controls")]
	[SerializeField] float PositionPitchFactor = -5f;
	[SerializeField] float ControlPitchFactor = -20f;
	[Header("Yaw Controls")]
	[SerializeField] float PositionYawFactor = 6.5f;
	[Header("Roll Controls")]
	[SerializeField] float ControlRollFactor = -20f;

	float XThrow, YThrow;
	bool haveControl = true; 

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
		if (!haveControl) { return; }
		ProccessTranslation();
		ProccessRotation();
	}

	private void ProccessRotation()
	{
		//Pitch Calclations
		float pitchDueToPosition = transform.localPosition.y * PositionPitchFactor;
		float pitchDueToControlThrow = YThrow * ControlPitchFactor;
		float Pitch = pitchDueToPosition + pitchDueToControlThrow;

		//Yaw Calculations
		float yawDueToPosition = transform.localPosition.x * PositionYawFactor;
		float Yaw = yawDueToPosition;

		//Roll Calculations
		float rollDueToControlThrow = XThrow * ControlRollFactor;
		float Roll = rollDueToControlThrow;

		transform.localRotation = Quaternion.Euler(Pitch,Yaw,Roll);
	}

	private void ProccessTranslation()
	{
		//Horizontal Move
		XThrow = CrossPlatformInputManager.GetAxis("Horizontal");
		float XOffset = XThrow * Speed * Time.fixedDeltaTime;

		//Vertical Move
		YThrow = CrossPlatformInputManager.GetAxis("Vertical");
		float YOffset = YThrow * Speed * Time.fixedDeltaTime;

		float RawNewPosX = transform.localPosition.x + XOffset;
		float RawNewPosY = transform.localPosition.y + YOffset;

		float ClampedXoffset = Mathf.Clamp(RawNewPosX, -XRange, XRange);
		float ClamedYoffset = Mathf.Clamp(RawNewPosY, -YRange, YRange);

		transform.localPosition = new Vector3(ClampedXoffset, ClamedYoffset, transform.localPosition.z);

	}

	private void SetControlStatus(bool status)
	{
		haveControl = status;
	}
}
