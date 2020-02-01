using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterScript : MonoBehaviour
{
	List<StoryEvent> storyEvents = new List<StoryEvent>();
<<<<<<< HEAD
	List<StoryResource> storyResources;
	myTextGui gui;

	void Awake(){		
		gui = gameObject.GetComponent(typeof(myTextGui)) as myTextGui;

=======
	[SerializeField] myTextGui gui;
	public GameObject canvas;

	void Awake(){
		gui = GetComponent<myTextGui>();
>>>>>>> 2297c5a0ca0ad165f1ac8189dd1ac97cbb0443da
	}

    // Start is called before the first frame update
    void Start()
    {
		EventDataReader reader = new EventDataReader();
		reader.readEventData("Assets/Businessdata/gameevents.txt", storyEvents);
		Debug.Log(storyEvents.Count + " events read from file.");

		StoryResourceReader resourceReader = new StoryResourceReader();
		storyResources = resourceReader.readResourceData ("Assets/Businessdata/resources.txt");
        
    }

    // Update is called once per frame
    void Update()
    {
		StoryEvent currentEvent = storyEvents[0];
		gui.showEvent(currentEvent);
		gui.updateResources (storyResources);
    }
}
