using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleParent : MonoBehaviour {

    public List<Transform> child = new List<Transform>();

    private void Awake()
    {
        foreach(Transform particle in this.transform)
        {
            child.Add(particle);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
