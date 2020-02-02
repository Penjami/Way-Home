using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using UnityEngine.UI;
using TMPro;


public class myTextGui : MonoBehaviour
{
    // Start is called before the first frame update

	public GameObject textBoxPrefab; 
	public GameObject canvas;
	StoryEvent storeCurrentEvent = null;
    [SerializeField] private TextMeshProUGUI _waterText;
    [SerializeField] private TextMeshProUGUI _oxygenText;
	[SerializeField] private TextMeshProUGUI _energyText;
    [SerializeField] private TextMeshProUGUI _steelText;
	[SerializeField] private TextMeshProUGUI _crewText;
    [SerializeField] private TextMeshProUGUI _foodText;
	//GameObject eventMainText;

	List<GameObject> eventBoxList = new List<GameObject>();
	MasterScript _masterScript;

    void Start()
    {
		//eventMainText = Instantiate(textBoxPrefab);
		//Debug.Log(eventMainText.GetComponent<Text>().text);
		_masterScript = GetComponent<MasterScript>();
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
		GameObject newEventText = Instantiate(textBoxPrefab);
		//Text newEventText = canvas.AddComponent<Text>();
		TextMeshProUGUI newText;
		newText = newEventText.GetComponentsInChildren<TextMeshProUGUI>()[1];
		newText.text = currentEvent.eventText;
		Button button = newEventText.GetComponentInChildren<Button>();
		button.onClick.AddListener(() => {_masterScript.StartNextEvent();});
		//newEventText.text = currentEvent.eventText;
		newEventText.transform.SetParent(canvas.transform, false);
		eventBoxList.Add(newEventText);			
	}

	public void updateResources(List<StoryResource> resources){
		string newText = "";
		for(int i = 0 ; i < resources.Count; i++){
			switch (resources[i].name)
			{
				case "Water":
					_waterText.text =  resources[i].amount.ToString();
				break;
				case "Oxygen":
					_oxygenText.text =  resources[i].amount.ToString();
				break;
				case "Energy":
					_energyText.text =  resources[i].amount.ToString();
				break;
				case "Steel":
					_steelText.text =  resources[i].amount.ToString();
				break;
				case "Crew":
					_crewText.text =  resources[i].amount.ToString();
				break;
				case "Food":
					_foodText.text =  resources[i].amount.ToString();
				break;
			}
		}
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
