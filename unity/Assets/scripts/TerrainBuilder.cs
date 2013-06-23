using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class TerrainBuilder : MonoBehaviour {

	// Use this for initialization
	void Start ()
  {
    string path = @"d:\test.txt";

    // Open the file to read from.
    using (StreamReader sr = File.OpenText(path))
    {
      string s = "";
      while ((s = sr.ReadLine()) != null)
      {
//        Debug.Log(s);
        Console.WriteLine(s);
      }
    }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
