using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject flipperL;
    public GameObject flipperR;
    public GameObject spring;
    static public GameObject ball;
    public float lTriggerValue;
    public float rTriggerValue;
    public float rStickValue;
    public float maxBallForce;
    public float hitStrength;
    public float damper;
    public float startPositionL;
    public float pressedPositionL;
    public float startPositionR;
    public float pressedPositionR;
    Vector3 springStartPosition;
    Vector3 springTargetPosition;
    static public float ballForce;
    bool springPulledBack;
    HingeJoint hingeL;
    HingeJoint hingeR;
    static public Vector3 ballStartPosition;
    static public float points;
    static public List<GameObject> spinners;

    private void Start()
    {
        ball = GameObject.Find("Ball");
        springStartPosition = spring.transform.localPosition;
        springTargetPosition = new Vector3(springStartPosition.x, springStartPosition.y, springStartPosition.z - 0.4f);
        hingeL = flipperL.GetComponent<HingeJoint>();
        hingeR = flipperR.GetComponent<HingeJoint>();
        ballStartPosition = ball.transform.position;
    }

    void Update()
    {
        rTriggerValue = Input.GetAxis("Fire1");
        lTriggerValue = Input.GetAxis("Fire2");
        rStickValue = Input.GetAxis("Vertical");
        if (rStickValue == 1)
        {
            spring.transform.localPosition = Vector3.MoveTowards(spring.transform.localPosition, springTargetPosition, 0.1f * Time.deltaTime);
            ballForce = Mathf.Min(maxBallForce, ballForce + Time.deltaTime);
            springPulledBack = true;
        }
        Debug.Log(Vector3.Distance(spring.transform.position, springStartPosition));
        if (Vector3.Distance(spring.transform.position, springStartPosition) < 8.51f)
        {
            springPulledBack = false;
            ballForce = 0;
        }
        if (rStickValue != 1 && springPulledBack)
        {
            spring.transform.localPosition = Vector3.MoveTowards(spring.transform.localPosition, springStartPosition, 5 * Time.deltaTime);
        }
        if (Input.GetButton("Reset"))
        {
            ResetGame();
        }
        JointSpring jointSpring = new JointSpring();
        jointSpring.spring = hitStrength;
        jointSpring.damper = damper;
        jointSpring.targetPosition = startPositionL + pressedPositionL * lTriggerValue;
        hingeL.spring = jointSpring;
        jointSpring.targetPosition = startPositionR + pressedPositionR * rTriggerValue;
        hingeR.spring = jointSpring;

    }
    public static void ResetGame()
    {
        if(Points.highScore< Points.points)
        {
            Points.highScore = Points.points;
        }
        Points.Save();
        EntranceBlock.OpenEntranceBlock();
        Points.points = 0;
        ball.transform.position = ballStartPosition;
        foreach (GameObject item in spinners)
        { 
            item.GetComponent<Spinner>().counter = 0;
        }
    }
}