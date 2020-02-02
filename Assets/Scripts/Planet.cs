using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    [SerializeField] private Transform _outerPlanet;
    [SerializeField] private Transform _innerPlanet;
    [SerializeField] private Transform _star;
    [SerializeField] private Transform _enemyShip;
    [SerializeField] private Transform _tradShip;


    private Vector3 _rotDir;

    // Start is called before the first frame update
    public void Start()
    {
        if(Random.Range(0f, 1f) < 0.25f) {
            _rotDir = new Vector3(Random.Range(0.5f, 3f), Random.Range(3f, 10f), 0);

            _outerPlanet.gameObject.SetActive(true);
            _innerPlanet.gameObject.SetActive(true);
            _star.gameObject.SetActive(false);
            _enemyShip.gameObject.SetActive(false);
            _tradShip.gameObject.SetActive(false);

            var renderer = _innerPlanet.GetComponent<Renderer>();


            renderer.material.SetColor("Color_1", new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));
            renderer.material.SetColor("Color_2", new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));
            renderer.material.SetColor("Color_3", new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));
            renderer.material.SetFloat("Noise_Offset", Random.Range(0f, 2000f));
        } else if(Random.Range(0f, 1f) < 0.5f) {
            _outerPlanet.gameObject.SetActive(false);
            _innerPlanet.gameObject.SetActive(false);
            _star.gameObject.SetActive(true);
            _enemyShip.gameObject.SetActive(false);
            _tradShip.gameObject.SetActive(false);

            var renderer = _star.GetComponent<Renderer>();


            renderer.material.SetColor("Color_1", Color.HSVToRGB(Random.Range(0f,1f),2.5f, 2.5f, true));

        } else if(Random.Range(0f, 1f) < 0.75f) {
            _outerPlanet.gameObject.SetActive(false);
            _innerPlanet.gameObject.SetActive(false);
            _star.gameObject.SetActive(false);
            _enemyShip.gameObject.SetActive(true);
            _tradShip.gameObject.SetActive(false);

        } else {
            _outerPlanet.gameObject.SetActive(false);
            _innerPlanet.gameObject.SetActive(false);
            _star.gameObject.SetActive(false);
            _enemyShip.gameObject.SetActive(false);
            _tradShip.gameObject.SetActive(true);

        }

    }

    public void SpawnStar(Color color) {
        _outerPlanet.gameObject.SetActive(false);
        _innerPlanet.gameObject.SetActive(false);
        _star.gameObject.SetActive(true);

        var renderer = _star.GetComponent<Renderer>();

        renderer.material.SetColor("Color_1", color * 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            Start();
        }
        _innerPlanet.eulerAngles += _rotDir * Time.deltaTime;
    }
}
