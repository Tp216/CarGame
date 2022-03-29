using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    private float HorizontalInput;
    private float VerticalInput;
    private float CurrentSteeringAngle;
    private float CurrentBreakForce;
    private bool IsBreaking;
    

    [SerializeField] private float MotorForce;
    [SerializeField] private float BreakForce;
    [SerializeField] private float MaxSteeringAngle;


    [SerializeField] private WheelCollider FLWCollider;
    [SerializeField] private WheelCollider FRWCollider;
    [SerializeField] private WheelCollider RLWCollider;
    [SerializeField] private WheelCollider RRWCollider;


    [SerializeField] Transform FLWTransform;
    [SerializeField] Transform FRWTransform;
    [SerializeField] Transform RLWTransform;
    [SerializeField] Transform RRWTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(0, 0, 90);
        }
    }
    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    private void GetInput()
    {
        HorizontalInput = Input.GetAxis(Horizontal);
        VerticalInput = Input.GetAxis(Vertical);
        IsBreaking = Input.GetKey(KeyCode.Space);
    }
    

    private void HandleMotor()
    {
        FLWCollider.motorTorque = VerticalInput * MotorForce;
        FRWCollider.motorTorque = VerticalInput * MotorForce;
        CurrentBreakForce = IsBreaking ? BreakForce : 0f;
        if (IsBreaking)
        {
            ApplyBreaking();
        }
        if (!IsBreaking)
        {
            FRWCollider.brakeTorque = FLWCollider.brakeTorque = RRWCollider.brakeTorque = RLWCollider.brakeTorque = 0f;
        }
    }

    private void ApplyBreaking()
    {
        FLWCollider.brakeTorque = CurrentBreakForce;
        FRWCollider.brakeTorque = CurrentBreakForce;
        RLWCollider.brakeTorque = CurrentBreakForce;
        RRWCollider.brakeTorque = CurrentBreakForce;
    }

    private void HandleSteering()
    {
        CurrentSteeringAngle = MaxSteeringAngle * HorizontalInput;
        FLWCollider.steerAngle = CurrentSteeringAngle;
        FRWCollider.steerAngle = CurrentSteeringAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(FLWCollider, FLWTransform);
        UpdateSingleWheel(FRWCollider, FRWTransform);
        UpdateSingleWheel(RLWCollider, RLWTransform);
        UpdateSingleWheel(RRWCollider, RRWTransform);
    }

    private void UpdateSingleWheel(WheelCollider WheelCollider, Transform WheelTransform)
    {
        Vector3 Pos;
        Quaternion Rot;
        WheelCollider.GetWorldPose(out Pos, out Rot);
        WheelTransform.rotation = Rot;
        WheelTransform.position = Pos;
    }
}
