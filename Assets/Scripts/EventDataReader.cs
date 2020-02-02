using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class EventDataReader{

	public void readEventData (string filename, StoryEventStore eventList){
		StreamReader reader = new StreamReader(filename);

		string line;
		while ((line = reader.ReadLine()) != null){
			line = line.Trim();
			if (line.Equals("<event>")){
				StoryEvent toBeRead = readEvent(reader);
				Debug.Log(toBeRead.name);
				//if (toBeRead != null){
					Debug.Log("Event added");
					eventList.storyEvents.Add(toBeRead);
				//} else {
				//	Debug.Log("null event read, something went wrong");
				//}
			}
		}
	}	

	StoryEvent readEvent(StreamReader reader){
		StoryEvent story = new StoryEvent();
		StoryEventResult result = null;
	
		string line;
		//next line is name of event
		line = reader.ReadLine();
		story.name = line;
		Debug.Log("title: " + line);

		while ((line = reader.ReadLine()) != null){
			line = line.Trim();
			if (line.Equals("</event>") || line.Equals("</choise>")){
				Debug.Log("returning: " + story.name);
				return story;
			}

			story.addLocation(line);
			Debug.Log("location " + line);

			if (line.Equals("<required>")){
				result = new StoryEventResult();
				
				// story
				line = reader.ReadLine();
				line = line.Trim();
				result.eventText = line;
				Debug.Log ("new result: " + result.eventText);

				// to do: fault tolerance
				while (!(line = reader.ReadLine()).Equals("</required>")){
					result.requirements.Add(parseResource(line));
				}



				story.addResult(result);
			}

			if (line.Equals("<result>")){
				while (!(line = reader.ReadLine().Trim()).Equals("</result>")){
					StoryResource temp = parseResource(line);
					Debug.Log("adding result component " + temp.name + " " + temp.amount);
					result.results.Add(temp);
					//result.results.Add(parseResource(line));
				}
			}

			if (line.Equals("<choises>")){
				while (!(line = reader.ReadLine().Trim()).Equals("</choises>")){
					Debug.Log("adding choise event " + line);
					result.choises.Add(line);
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
