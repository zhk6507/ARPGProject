using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour {
    public Button[] btns;
    public AudioSource click;
	// Use this for initialization
	void Start () {
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].onClick.AddListener(delegate {
                click.Play();
            });
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
