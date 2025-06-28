using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpringHub : MonoBehaviour
{
    [SerializeField] private float springStartTime;
    [SerializeField] private float springRestartTime;
    [SerializeField] float angle;
    private HingeJoint joint;
    private JointSpring newJoint;

    private IgnoreCollision collision;

    void Start()
    {
        collision = GetComponent<IgnoreCollision>();
        joint = GetComponent<HingeJoint>();
        StartCoroutine(SpringCycle());
    }
    
    private IEnumerator SpringCycle()
    {
        while (true)
        {
            StartSpring();      //нат€гиваем
            yield return new WaitForSeconds(springRestartTime);
            RestartSpring();    //отпускаем
            yield return new WaitForSeconds(springStartTime);
        }
    }           
    private void StartSpring()
    {
        collision.SwitchCollision(true);
        newJoint = joint.spring;
        newJoint.targetPosition = angle;
        joint.spring = newJoint;

    }
    private void RestartSpring()
    {
        collision.SwitchCollision(false);
        newJoint.targetPosition = 0;
        joint.spring = newJoint;
    }
}
