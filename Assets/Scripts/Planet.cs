using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    [SerializeField] private Transform _outerPlanet;
    [SerializeField] private Transform _innerPlanet;

    private Vector3 _rotDir;

    // Start is called before the first frame update
    void Start()
    {
        _rotDir = new Vector3(Random.Range(0.5f, 3f), Random.Range(3f, 10f), 0);

        var renderer = _innerPlanet.GetComponent<Renderer>();

        renderer.material.SetColor("Color_1", new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));
        renderer.material.SetColor("Color_2", new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));
        renderer.material.SetColor("Color_3", new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));
        renderer.material.SetFloat("Noise_Offset", Random.Range(0f, 2000f));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            Start();
        }
        _innerPlanet.eulerAngles += new Vector3(0,10 * Time.deltaTime, 0);
    }
}
