using UnityEngine;
using System.Collections;

public class House : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
  {
    transform.Translate(0.0f, 0.001f, 0.0f);
	}
}
