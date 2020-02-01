using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEvent : MonoBehaviour
{

	public string eventText = ""; // description of event
	List<StoryEventRequirement> requirements = new List<StoryEventRequirement>(); // things needed for event to be success
	List<StoryEvent> choises = new List<StoryEvent>(); // options for next action
	List<StoryResource> successResources = new List<StoryResource>(); // consequences of success
	List<StoryResource> failureResources = new List<StoryResource>(); // consequences of failure

	public StoryEvent(){}

	public StoryEvent(string text){
		eventText = text;
	}

	public void addRequirement(StoryEventRequirement addition){
		requirements.Add(addition);
	}

	public void addChoise(StoryEvent addition){
		choises.Add(addition);
	}

	public void addFailure(StoryResource addition){
		failureResources.Add(addition);
	}

	public void addSuccess(StoryResource addition){
		successResources.Add(addition);
	}

	public List<StoryResource> getResults(){
		if (getPossible()){
			return successResources;
		} else {
			return failureResources;
		}
	}

	// is the event possile
	public bool getPossible(){
		return true;
	}

	// get description of what will happen or why event is not possible
	public string getResultText(){
		return eventText;
	}
		
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
