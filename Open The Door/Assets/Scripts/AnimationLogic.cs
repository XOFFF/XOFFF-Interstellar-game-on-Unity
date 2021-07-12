using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationLogic : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    public bool condition = false;

    public void OpenObject()
    {
        condition = true;
        animator.SetTrigger("Open");
    }

    public void CloseObject()
    {
        condition = false;
        animator.SetTrigger("Close");
    }
}
