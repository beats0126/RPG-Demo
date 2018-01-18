using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSceneGUI : MonoBehaviour {

    public Transform particleParent;
    ParticleParent parent;

    int counter;

    void Awake()
    {
        parent = particleParent.GetComponent<ParticleParent>();
    }

    public void onNextButtonClick()
    {
        counter += 1;
        resetCounter();
        enableParticle();
    }

    void resetCounter()
    {
        if (counter == parent.child.Count)
        {
            counter = 0;
        }
    }

    void enableParticle()
    {
        for (int i = 0; i < parent.child.Count; i++)
        {
            parent.child[i].gameObject.SetActive(false);
            if(i == counter)
            {
                parent.child[i].gameObject.SetActive(true);
            }
        }
    }
}
