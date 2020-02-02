using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEventResult {

	public string eventText = ""; // description of event
	public List<StoryResource> requirements = new List<StoryResource>(); // things needed for this event resolution
	public List<StoryResource> results = new List<StoryResource>(); // consequences of resolution
	public List<string> choises = new List<string>(); // options for next action by event name

	public bool checkResult(StoryResourceStore store){
		//Debug.Log("Running event check");
		for (int i = 0; i < requirements.Count; i++){
			//Debug.Log("Checking: " + requirements[i].name + " ");
			if(store.getResource(requirements[i].name) < requirements[i].amount){
				//Debug.Log("Not enought");
				return false;
			}
		}
		return true;
	}

	public void processResult(StoryResourceStore store){
		Debug.Log("processing " + results.Count + " results");
		for (int i = 0; i < results.Count; i++){
			Debug.Log("removing " + results[i].amount + " " + results[i].name);
			store.addResource(results[i].name, results[i].amount);
		}
	}

	public void addChoise(string addition){
		choises.Add(addition);
	}
}
