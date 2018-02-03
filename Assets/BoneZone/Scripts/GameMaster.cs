using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public GameObject i;
    public bool InvOpen;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadLevel(0);
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            i.SetActive(!i.active);
        }
    }

    public void LoadLevel(int l)
    {
        Application.LoadLevel(l);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
