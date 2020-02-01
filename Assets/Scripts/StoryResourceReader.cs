using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class StoryResourceReader{
	public List<StoryResource> readResourceData (string filename){
		List<StoryResource> resourceList = new List<StoryResource>();
		StreamReader reader = new StreamReader(filename);

		string line;
		while ((line = reader.ReadLine()) != null){
			line = line.Trim();
			string[] lines = line.Split(' ');
			if (lines.Length == 2) {
				string name = lines [0];
				int amount = Int32.Parse (lines [1]); 
				StoryResource required = new StoryResource (name, amount);
				resourceList.Add (required);
			}
		}
		return resourceList;
	}	

}
