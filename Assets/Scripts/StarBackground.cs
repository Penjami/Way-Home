using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBackground : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;

    private List<GameObject> _stars = new List<GameObject>();
    private List<GameObject> _removeStars = new List<GameObject>();


    private float _timer;
    private float _starSpawnTime;

    void Update() {
        _timer += Time.deltaTime;
        if(_timer > _starSpawnTime) {
            SpawnStars();
            _timer = 0;
            _starSpawnTime = Random.Range(0.1f, 0.3f);
        }
        MoveStars();
    }

    void SpawnStars() {
        var star = Instantiate(starPrefab, new Vector3(0,Random.Range(-40f, 40f), Random.Range(0f, 100f)), Quaternion.identity);
        _stars.Add(star);
    }

    void MoveStars() {
        var movement = new Vector3(10f,0,0);
        foreach (var star in _stars) {
            star.transform.position -= movement * Time.deltaTime;
            if (star.transform.position.x > 200) {
                _stars.Remove(star);
                _removeStars.Add(star);
            }
        }
        foreach (var removeStar in _removeStars) {
            Destroy(removeStar);
        }
        _removeStars.Clear();
    }
}
