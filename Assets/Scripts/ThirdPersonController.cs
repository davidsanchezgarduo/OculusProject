using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    private Animator playerAnimator;
    public Transform objectToGrab;
    private AnimatorStateInfo currentState;
    private CapsuleCollider capsule;
    private Touch fingerTouch;
    private Vector2 posInit;
    private Vector2 swipeDirection;
    private bool active;
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        capsule = GetComponent<CapsuleCollider>();
        active = true;
    }

    public void ActiveController(bool state)
    {
        active = state;
        if (!active)
            playerAnimator.SetFloat("Speed", 0f);
    }

    void Update()
    {
        if (!active)
            return;
        currentState = playerAnimator.GetCurrentAnimatorStateInfo(0);
#if UNITY_STANDALONE || UNITY_EDITOR
        playerAnimator.SetFloat("Speed", Input.GetAxis("Vertical"));
        playerAnimator.SetFloat("Direction", Input.GetAxis("Horizontal"));
#endif
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
#if !ACCEL_CONTROLLER && !SWIPE_CONTROLLER
        playerAnimator.SetFloat("Speed", 1f);
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > (Screen.width * 0.5f))
                playerAnimator.SetFloat("Direction", 1f);
            else
                playerAnimator.SetFloat("Direction", -1f);
        }
        else
            playerAnimator.SetFloat("Direction", 0f);
#endif
#if ACCEL_CONTROLLER
        playerAnimator.SetFloat("Direction", Input.acceleration.x);
        if (Input.touchCount > 0)
            playerAnimator.SetFloat("Speed", 1f);
        else
            playerAnimator.SetFloat("Speed", 0f);
#endif
#if SWIPE_CONTROLLER
        playerAnimator.SetFloat("Direction", Input.acceleration.x);
        if (Input.touchCount > 0)
        {
            for (int i = 0; i < Input.touchCount; i++)
            {
                fingerTouch = Input.GetTouch(i);
                if (fingerTouch.position.x > (Screen.width * 0.5f))
                {
                    switch (fingerTouch.phase)
                    {
                        case TouchPhase.Ended:
                        case TouchPhase.Canceled:
                            playerAnimator.SetFloat("Speed", 0f);
                            break;
                        default:
                            playerAnimator.SetFloat("Speed", 1f);
                            break;
                    }
                }
                else
                {
                    // Evaluar Swipe
                    switch (fingerTouch.phase)
                    {
                        case TouchPhase.Began:
                            posInit = fingerTouch.position;
                            break;
                        case TouchPhase.Ended:
                            swipeDirection = fingerTouch.position - posInit;
                            if (swipeDirection.magnitude < 10f)
                                return;
                            swipeDirection.Normalize();
                            if (Mathf.Abs(Vector2.Angle(Vector2.up, swipeDirection)) < 15f)
                                if (currentState.IsName("Locomotion"))
                                    playerAnimator.SetTrigger("Jump");
                            break;
                    }
                }
            }
        }
#endif
#endif
        if (Input.GetKeyDown(KeyCode.Space) && currentState.IsName("Locomotion"))
            playerAnimator.SetTrigger("Jump");
        if (Input.GetKeyDown(KeyCode.Q))
            playerAnimator.SetTrigger("Wave");
        if (Input.GetKeyDown(KeyCode.G))
            playerAnimator.SetTrigger("Grab");
        if (currentState.IsName("Jump"))
        {
            Physics.gravity = Vector3.down * (playerAnimator.GetFloat("Gravity"));
            capsule.height = playerAnimator.GetFloat("CapsuleHeight");
        }
        else
        {
            capsule.height = 1.11f;
            Physics.gravity = Vector3.down * 9.81f;
        }
    }

    // Apply Inverse Kinematics to move the model's hand to the position
    // of the desired object to grab without having to change the whole animation
    void OnAnimatorIK()
    {
        //Just apply IK if the model is trying to grab something
        if (currentState.IsName("GrabNeutral"))
        {
            playerAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1.0f);
            playerAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1.0f);
            playerAnimator.SetIKPosition(AvatarIKGoal.RightHand, objectToGrab.position);
            playerAnimator.SetIKRotation(AvatarIKGoal.RightHand, objectToGrab.rotation);
        }
    }
}
