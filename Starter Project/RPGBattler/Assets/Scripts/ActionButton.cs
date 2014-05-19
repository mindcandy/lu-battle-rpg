using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {

	public delegate void ButtonDelegate();

	private ButtonDelegate _onButtonClicked;

	public void addClickHandler(ButtonDelegate onButtonClicked)
	{
		_onButtonClicked = onButtonClicked;
	}

	void OnMouseDown () 
	{
		if(_onButtonClicked != null)
		{
			_onButtonClicked();
		}
	}
}
