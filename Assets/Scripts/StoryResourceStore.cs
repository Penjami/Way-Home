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
		return true;
	}

	// false if resource didn't exist
	public bool removeResource (string name, int amount){
		int store;
		try {
			store = storyResources[name];
		} catch {
			Debug.Log("Trying to remove non-existent resource " + name);
			return false;
		}
		storyResources[name] -= amount;
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
