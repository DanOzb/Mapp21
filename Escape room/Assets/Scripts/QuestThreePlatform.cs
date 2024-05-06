using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestThreePlatform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        HingeJoint hinge = GetComponent<HingeJoint>();

        // Make the spring reach shoot for a 70 degree angle.
        // This could be used to fire off a catapult.

        JointSpring hingeSpring = hinge.spring;
        hingeSpring.spring = 10;
        hingeSpring.damper = 3;
        hingeSpring.targetPosition = 70;
        hinge.spring = hingeSpring;
        hinge.useSpring = true;
    }
}
