using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarBackground : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;

    private List<GameObject> _stars = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnStars());
        StartCoroutine(MoveStars());
    }

    IEnumerator SpawnStars() {
        while (true) {
            var star = Instantiate(starPrefab, new Vector3(0,Random.Range(-40f, 40f),0), Quaternion.identity);
            _stars.Add(star);
            yield return new WaitForSeconds(Random.Range(0.1f, 0.3f));;
        }
    }

    IEnumerator MoveStars() {
        var movement = new Vector3(-0.2f,0,0);
        while (true) {
            foreach (var star in _stars) {
                star.transform.position -= movement;
                if (star.transform.position.x > 200) {
                    _stars.Remove(star);
                    Destroy(star);
                }
            }

            yield return null;
        }
    }
}
