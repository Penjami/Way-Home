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
	Transform canvasTransform;
	StoryEvent storeCurrentEvent = null;
	GameObject eventMainText;

	List<GameObject> eventBoxList = new List<GameObject>();

	public myTextGui(Transform canvas){
		canvasTransform = canvas;
	}

    void Start()
    {
		eventMainText = Instantiate(textBoxPrefab);
		Debug.Log(eventMainText.GetComponent<Text>().text);
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("update" + eventMainText.GetComponent<Text>().text);
    }

	public void showEvent(StoryEvent currentEvent){
		//if (currentEvent == storeCurrentEvent){
		//	Debug.Log("old event");
		//	return;
		//}

		Debug.Log("new event");
		Debug.Log(eventMainText.GetComponent<Text>().text);
		//eventBoxList.Clear();
		//GameObject newEventText = 
		//	Instantiate(textBoxPrefab);
		Text newText;
		newText = eventMainText.GetComponent<Text>();
		newText.text = currentEvent.eventText;
		//eventBoxList.Add(newEventText);			
		//		Debug.Log("Current event: " + currentEventText);
		//currentEventText = currentEvent.eventText;
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
