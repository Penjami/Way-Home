using UnityEngine;

public class MasterScript : MonoBehaviour
{
	public GameObject _endScreen;
	public GameObject _winScreen;
	StoryEventStore storyEvents = new StoryEventStore();
	public StoryResourceStore storyResources = new StoryResourceStore();
	myTextGui gui;
	bool newEvent = true; // do we process new event next update?
	private int eventCounter;

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

	public void GameOver() {
		_endScreen.SetActive(true);
		Time.timeScale = 0;
	}

    // Update is called once per frame
    public void StartNextEvent(string target)
    {
		StoryEvent currentEvent = storyEvents.getRandomEvent(target);
		gui.showEvent(currentEvent);
		gui.updateResources (storyResources);
		eventCounter++;
		if(eventCounter > 20) {
			_winScreen.SetActive(true);
			Time.timeScale = 0;
		}
	}
}
