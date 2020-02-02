using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEventStore {
	StoryEvent defaultEvent = new StoryEvent();
	public List<StoryEvent> storyEvents = new List<StoryEvent>();

	public StoryEventStore(){
		defaultEvent.name = "Default";
		StoryEventResult defaultResult = new StoryEventResult();
		defaultResult.eventText = "Nothing happens. Seems that developers of this game have not implemented this event.";
	}

	public StoryEvent getRandomEvent(string location){
		Debug.Log("serching for event in " + location);
		for (int i = 0; i < 1000; i++){
			int index = Random.Range(0, storyEvents.Count);
			if (storyEvents[index].getLocations().Contains(location)){
				return storyEvents[index];
			}
		}
		Debug.Log("Any event on location " + location + "not found");
		return defaultEvent;
	}

	public StoryEvent getEventByName(string name){
		for(int i = 0; i < storyEvents.Count; i++){
			if (storyEvents[i].name == name){
				return storyEvents[i];
			}
		}
		Debug.Log("Requested event " + name + " not found");
		return defaultEvent;
	}
}
