using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.UI;


public class myTextGui : MonoBehaviour
{
    // Start is called before the first frame update

	public GameObject textBoxPrefab; 
	public GameObject canvas;

	//GameObject eventMainText;

	List<GameObject> eventBoxList = new List<GameObject>();
	GameObject resourceText;

    void Start()
    {
		//eventMainText = Instantiate(textBoxPrefab);
		//Debug.Log(eventMainText.GetComponent<Text>().text);
		resourceText = Instantiate(textBoxPrefab, new Vector3(-Screen.width/2 + 150, Screen.height/2-50, 0), Quaternion.identity);
		resourceText.transform.SetParent(canvas.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log("update" + eventMainText.GetComponent<Text>().text);
    }

	public void showEvent(string eventText){

		Debug.Log("new event");

		eventBoxList.ForEach(Destroy);
		eventBoxList.Clear();
		GameObject newEventText = Instantiate(textBoxPrefab, Vector3.zero, Quaternion.identity);
		//Text newEventText = canvas.AddComponent<Text>();
		Text newText;
		newText = newEventText.GetComponent<Text>();
		newText.text = eventText;
		//newEventText.text = currentEvent.eventText;
		newEventText.transform.SetParent(canvas.transform, false);
		eventBoxList.Add(newEventText);			
	}

	public void updateResources(List<StoryResource> resources){
		string newText = "";
		for(int i = 0 ; i < resources.Count; i++){
			newText = newText + resources[i].name + " " + resources[i].amount + "\n";
		}
		Text tempText;
		tempText = resourceText.GetComponent<Text>();
		tempText.text = newText;
		//newEventText.text = currentEvent.eventText;
	}


	/*
	 * for reference only
	GameObject CreateText(Transform canvas_transform, float x, float y, string text_to_print, int font_size, Color text_color)
	{
		GameObject UItextGO = new GameObject("Text2");
		UItextGO.transform.SetParent(canvas_transform);

		RectTransform trans = UItextGO.AddComponent<RectTransform>();
		trans.anchoredPosition = new Vector2(x, y);

		Text text = UItextGO.AddComponent<Text>();
		text.text = text_to_print;
		text.fontSize = font_size;
		text.color = text_color;

		return UItextGO;
	}
	*/



	/*
    this stuff is now totally broken
	void OnGUI(){
		Debug.Log("Current event on GUI: " + currentEventText);
		GUILayout.Button("Tässä tekstiä");
		GUILayout.Button(currentEventText + "a");
		GUI.TextField(new Rect(Screen.width-200,20+30,300,300), currentEventText + "a");
	}
	*/
			
}
