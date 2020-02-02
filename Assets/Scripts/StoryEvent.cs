using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryEvent
{
	public string name; //name of event
	List<StoryEventResult> results = new List<StoryEventResult>(); // possible outcomes ordered in order of preference (best is first)

	public StoryEvent(){}

	public void addResult(StoryEventResult addition){
		results.Add(addition);
	}



	public string getResults(StoryResourceStore store){
		//Debug.Log("Event " + name);
		//Debug.Log("getting results for new event, " + results.Count);
		for (int i = 0; i < results.Count; i++){
			//Debug.Log("checking....");
			if( results[i].checkResult(store)){
				results[i].processResult(store);
				return results[i].eventText;
			}
		}
		return "You were unable to do anything (this is error in event results)";
	}
}
