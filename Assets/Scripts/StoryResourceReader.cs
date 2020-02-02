using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class StoryResourceReader{
	public List<StoryResource> readResourceData (string filename, StoryResourceStore store){
		List<StoryResource> resourceList = new List<StoryResource>();
		StreamReader reader = new StreamReader(filename);

		string line;
		while ((line = reader.ReadLine()) != null){
			line = line.Trim();
			string[] lines = line.Split(' ');
			if (lines.Length == 2) {
				string name = lines [0];
				int amount = Int32.Parse (lines [1]);
				store.addResource(name, amount);
			}
		}
		return resourceList;
	}	

}
