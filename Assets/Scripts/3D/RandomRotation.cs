using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour
{
    private Vector3 randomRotation;

    // Use this for initialization
    void Start()
    {
        randomRotation = new Vector3(Random.value, Random.value, Random.value);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation *= Quaternion.Euler(randomRotation);
    }
}
