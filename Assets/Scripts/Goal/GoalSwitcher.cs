using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSwitcher : MonoBehaviour {

    public float goalSwitchTime = 2f;
    private Goal goal_script;
    private int goal_index = 0;
    public List<GameObject> ordered_goals;
    private float time_since_goal_switch = 0f;

    public GameObject boidOne;
    public GameObject boidTwo;
    public float speed = 0;
    Vector3 lastPosition = Vector3.zero;
    string text;
    // Use this for initialization

    void Start()
    {
        goal_script = GetComponent<Goal>();
        goal_script.setGoal(ordered_goals[goal_index]);
    }
	
    void FixedUpdate()
    {
        if (goal_index == 1)
        {
            speed = (boidTwo.transform.position - lastPosition).magnitude;
            lastPosition = boidTwo.transform.position;
            text += "\n" + "Dyno Boid Time: " + time_since_goal_switch + " Dyno Speed: " + speed;
            if(speed == 0)
            {
                
            }
          
            // Debug.Log();
        }
        else if(goal_index == 2)
        {
            Debug.Log(text);
        }
    }

	// Update is called once per frame
	void Update () {
        time_since_goal_switch += Time.deltaTime;

        if (time_since_goal_switch > goalSwitchTime)
        {
            if (goal_index >= ordered_goals.Count - 1)
            {
                goal_index = 0;
            }
            else
            {
                goal_index += 1;
            }
            goal_script.setGoal(ordered_goals[goal_index]);
            time_since_goal_switch = 0f;
        }

       

        //if (boidOne.transform.position == ordered_goals[goal_index].transform.position)
        //{
        //    if (goal_index >= ordered_goals.Count - 1)
        //    {
        //        goal_index = 0;
        //    }
        //    else
        //    {
        //        goal_index += 1;
        //    }
        //    goal_script.setGoal(ordered_goals[goal_index]);
        //    time_since_goal_switch = 0f;
        //}

    }
}
