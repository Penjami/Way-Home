using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryResourceStore {
	IDictionary<string, int> storyResources = new Dictionary<string, int>();

	// set amount of resource
	public bool setResource (string name, int amount){
		storyResources[name] = amount;
		return true;
	}

	// get amount of resource, 0 if not on list
	public int getResource (string name){
		try{
			return storyResources[name];
		} catch {
			Debug.Log("resource not found: " + name);
			return 0;
		}
		Debug.Log("you shouldn't be here");
		return 0;
	}

	//add amount of resource, false if resource is new
	public bool addResource (string name, int amount){
		int store;
		try {
			store = storyResources[name];
		} catch {
			setResource (name, amount);
			return false;
		}
		storyResources[name] += amount;
		switch (name) {
			case "food":
				if(storyResources[name] < 0) {
					GameObject.FindObjectOfType<MasterScript>().GameOver();
				}
			break;
			case "oxygen":
				if(storyResources[name] < 0) {
					GameObject.FindObjectOfType<MasterScript>().GameOver();
				}
			break;
			case "water":
				if(storyResources[name] < 0) {
					GameObject.FindObjectOfType<MasterScript>().GameOver();
				}
			break;
			case "energy":
				if(storyResources[name] < 0) {
					GameObject.FindObjectOfType<MasterScript>().GameOver();
				}
			break;
		}
		var part = GameObject.Find(name);
		if (part != null) {
			if(amount < 0) {
				part.GetComponent<ShipPart>().SetPartStatus(PartStatus.BROKEN);
			} else {
				part.GetComponent<ShipPart>().SetPartStatus(PartStatus.OK);
			}
		}
		return true;
	}

	public List<StoryResource> getList(){
		List<StoryResource> lista = new List<StoryResource>();
		foreach(KeyValuePair<string, int> kvp in storyResources){
			lista.Add(new StoryResource(kvp.Key, kvp.Value));
		}
		return lista;
	}

	//public bool addResource (StoryResource reso) 
}
