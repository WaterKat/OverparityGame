using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePlayerAnimationUpdater : MonoBehaviour
{
    public int fakePlayerState = 0;
    public Animator fakeAnimator;
    private void Start()
    {
        fakeAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        switch (fakePlayerState)
        {
            case 0:
                fakeAnimator.SetBool("isWalking", false);
                fakeAnimator.SetFloat("VelocityY", 0);
                fakeAnimator.SetFloat("VelocityX", 0);
                fakeAnimator.SetFloat("VelocityTotal", 0);
                break;
            case 1:
                fakeAnimator.SetBool("isWalking", true);
                fakeAnimator.SetFloat("VelocityY", 10);
                fakeAnimator.SetFloat("VelocityX", 10);
                fakeAnimator.SetFloat("VelocityTotal", 10);
                break;
            case 2:
                fakeAnimator.SetBool("isWalking", false);
                fakeAnimator.SetFloat("VelocityY", 0);
                fakeAnimator.SetFloat("VelocityX", 0);
                fakeAnimator.SetFloat("VelocityTotal", 0);
                fakeAnimator.SetTrigger("isDamaged");
                break;
            case 3:
                fakeAnimator.SetBool("isWalking", false);
                fakeAnimator.SetFloat("VelocityY", 0);
                fakeAnimator.SetFloat("VelocityX", 0);
                fakeAnimator.SetFloat("VelocityTotal", 0);
                fakeAnimator.SetTrigger("isAttacking");
                break;
            default:
                break;
        }
    }
}
