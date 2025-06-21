using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpringHub : MonoBehaviour
{
    [SerializeField] private SpringTimer springTimer;
    [SerializeField] float angle;
    private HingeJoint joint;
    private JointSpring newJoint;


    void Start()
    {
        joint = GetComponent<HingeJoint>();
        StartSpring();
    }
  
    private void StartSpring()
    {
        newJoint = joint.spring;
        newJoint.targetPosition = angle;
        joint.spring = newJoint;
        Debug.Log($"{joint.spring.targetPosition}");
        springTimer.Restart();
    }

    public void OnSpringTimerOver()
    {
        newJoint.targetPosition = 0;
        joint.spring = newJoint;
        Debug.Log($"{joint.spring.targetPosition}");
        StartCoroutine(ResetSpring());
    }

    private IEnumerator ResetSpring()
    {
        yield return new WaitForSeconds(2f);
        StartSpring();
    }
}
