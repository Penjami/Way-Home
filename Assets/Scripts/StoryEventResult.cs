using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEventResult {

	public string eventText = ""; // description of event
	public List<StoryResource> requirements = new List<StoryResource>(); // things needed for this event resolution
	public List<StoryResource> successResources = new List<StoryResource>(); // consequences of resolution
}
