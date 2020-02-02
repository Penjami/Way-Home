using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MasterScript : MonoBehaviour
{
	List<StoryEvent> storyEvents = new List<StoryEvent>();
	StoryResourceStore storyResources = new StoryResourceStore();
	myTextGui gui;
	bool newEvent = true; // do we process new event next update?

	void Awake(){		
		gui = gameObject.GetComponent(typeof(myTextGui)) as myTextGui;
	}

    // Start is called before the first frame update
    void Start()
    {
		EventDataReader reader = new EventDataReader();
		reader.readEventData("Assets/Businessdata/gameevents.txt", storyEvents);
		Debug.Log(storyEvents.Count + " events read from file.");

		StoryResourceReader resourceReader = new StoryResourceReader();

		resourceReader.readResourceData ("Assets/Businessdata/resources.txt", storyResources);
    	
		StartNextEvent();

    }

    // Update is called once per frame
    public void StartNextEvent()
    {
		StoryEvent currentEvent = storyEvents[Random.Range(0, storyEvents.Count - 1)];
		gui.showEvent(currentEvent);
		gui.updateResources (storyResources);
		
		if(newEvent){
			StoryEvent currentEvent = storyEvents[0];
			string eventText = currentEvent.getResults(storyResources);
			gui.showEvent(eventText);
			newEvent = false;
		}

		gui.updateResources (storyResources.getList());
    }
}
