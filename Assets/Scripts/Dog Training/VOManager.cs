using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VOManager : MonoBehaviour {

	List<VOSource> sources = new List<VOSource>();
	// Use this for initialization
	void Start () {
		for (int i = 0; i < transform.childCount; i++)
		{
			Transform child = transform.GetChild(i);
			VOSource source = child.GetComponent<VOSource>();
			sources.Add(source);
			source.manager = this;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void PlayVoice(VOSource source)
	{
		foreach (VOSource s in sources)
		{
			if (s != source) s.audio.Stop();
		}
		source.audio.Play();
	}
}
