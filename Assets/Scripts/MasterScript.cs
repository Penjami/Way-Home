using UnityEngine;

public class MasterScript : MonoBehaviour
{
	StoryEventStore storyEvents = new StoryEventStore();
	public StoryResourceStore storyResources = new StoryResourceStore();
	myTextGui gui;
	bool newEvent = true; // do we process new event next update?

	void Awake(){		
		gui = gameObject.GetComponent(typeof(myTextGui)) as myTextGui;
	}

    // Start is called before the first frame update
    void Start()
    {
		EventDataReader reader = new EventDataReader();
		reader.readEventData(Application.streamingAssetsPath + "/gameevents.txt", storyEvents);
		// Debug.Log(storyEvents.Count + " events read from file.");

		StoryResourceReader resourceReader = new StoryResourceReader();

		resourceReader.readResourceData (Application.streamingAssetsPath + "/resources.txt", storyResources);

		gui.updateResources (storyResources);

		StartNextEvent("beginning");

    }

    // Update is called once per frame
    public void StartNextEvent(string target)
    {
		StoryEvent currentEvent = storyEvents.getRandomEvent(target);
		gui.showEvent(currentEvent);
		gui.updateResources (storyResources);
	}
}
