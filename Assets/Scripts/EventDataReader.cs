using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class EventDataReader{

	public void readEventData (string filename, List<StoryEvent> eventList){
		StreamReader reader = new StreamReader(filename);

		string line;
		while ((line = reader.ReadLine()) != null){
			line = line.Trim();
			if (line.Equals("<event>")){
				StoryEvent toBeRead = readEvent(reader);
				Debug.Log(toBeRead.eventText);
				//if (toBeRead != null){
					Debug.Log("Event added");
					eventList.Add(toBeRead);
				//} else {
				//	Debug.Log("null event read, something went wrong");
				//}
			}
		}
	}	

	StoryEvent readEvent(StreamReader reader){
		StoryEvent story = new StoryEvent();
		string line;
		while ((line = reader.ReadLine()) != null){
			line = line.Trim();
			if (line.Equals("</event>") || line.Equals("</choise>")){
				Debug.Log("returning: " + story.eventText);
				return story;
			}
			if (line.Equals("<description>")){
				string description;
				description = reader.ReadLine();
				story.eventText = description;
				Debug.Log(description);
				if (!reader.ReadLine().Equals("</description>")){
					Debug.Log("event multiline descriptions not supported yet");
				}
			}
			if (line.Equals("<requirement>")){
				StoryEventRequirement requirement = new StoryEventRequirement();
				// to do: fault tolerance
				line = reader.ReadLine();
				line = line.Trim();
				string[] lines = line.Split(' ');
				string name = lines[0];
				int amount = Int32.Parse(lines[1]); 
				StoryResource required = new StoryResource(name, amount);
				requirement.storyEventFailText = reader.ReadLine();
				requirement.resource = required;
				story.addRequirement(requirement);
				if (!reader.ReadLine().Equals("</requirement>")){
					Debug.Log("requirement multiline descriptions not supported yet");
				}
			}
			if (line.Equals("<success>")){
				while (!(line = reader.ReadLine().Trim()).Equals("</success>")){
					story.addSuccess(parseResource(line));
				}
			}
			if (line.Equals("<failure>")){
				while (!(line = reader.ReadLine().Trim()).Equals("</failure>")){
					story.addFailure(parseResource(line));
				}
			}

		}


		Debug.Log("file ended prematurely, event not properly terminated.");
		return story;
	}

	StoryResource parseResource(string line){
		string[] lines = line.Split(' ');
		string name = lines[0];
		int amount = Int32.Parse(lines[1]); 
		StoryResource resource = new StoryResource(name, amount);
		return resource;
	}

  
}
