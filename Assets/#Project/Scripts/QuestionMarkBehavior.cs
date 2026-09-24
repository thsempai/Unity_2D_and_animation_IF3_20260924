using UnityEngine;

[RequireComponent(typeof(Animator))]
public class QuestionMarkBehavior : MonoBehaviour
{

    private const string ANIMATION_ROTATE = "rotate";
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool rotate = !animator.GetBool(ANIMATION_ROTATE);
        animator.SetBool(ANIMATION_ROTATE, rotate);
    }

}
