using UnityEngine;
using System.Collections;

public class RandomRun : MonoBehaviour
{
    public float range = 3.0f;
    public float turnInterval = 1.5f;
    public float dampTime = 0.25f;

    Vector3 target;

    IEnumerator Start()
    {
        while (true)
        {
            target = Random.insideUnitCircle * range;
            yield return new WaitForSeconds(turnInterval * Random.Range(0.5f, 1.5f));
        }
    }

    void Update()
    {
        var animator = GetComponent<Animator>();

        int rand = UnityEngine.Random.Range(0, 50);
        animator.SetBool("Jump", rand == 20);
        animator.SetBool("Dive", rand == 30);

        animator.SetFloat("Speed", 1, dampTime, Time.deltaTime);

        Vector3 curentDir = animator.rootRotation * Vector3.forward;
        Vector3 wantedDir = (target - animator.rootPosition).normalized;

        if (Vector3.Dot(curentDir, wantedDir) > 0)
        {
            animator.SetFloat("Direction", Vector3.Cross(curentDir, wantedDir).y, dampTime, Time.deltaTime);
        }
        else
        {
            animator.SetFloat("Direction", Vector3.Cross(curentDir, wantedDir).y > 0 ? 1 : -1, dampTime, Time.deltaTime);
        }
    }

    void OnAnimatorMove()
    {
        var animator = GetComponent<Animator>();
        transform.position = animator.rootPosition;
        transform.rotation = animator.rootRotation;
    }
}
