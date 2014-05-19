using UnityEngine;
using System.Collections;

public class ActionController1 : MonoBehaviour {
	
	public GameObject attackBtn;
	public GameObject magicBtn;
	public GameObject healBtn;

	public GameObject infoBar;
	
	public GameObject progressBar;

	public float actionRechargeSpeed = 0.01f;
	
	private bool _waiting = false;
	
	void Start () 
	{
		attackBtn.GetComponent<ActionButton>().addClickHandler(onAttackClicked);
		magicBtn.GetComponent<ActionButton>().addClickHandler(onMagicClicked);
		healBtn.GetComponent<ActionButton>().addClickHandler(onHealClicked);
	}

	void Update () 
	{
		if(_waiting)
		{
			progressBar.GetComponent<ProgressBar>().addProgress(actionRechargeSpeed);
			if(progressBar.GetComponent<ProgressBar>().isFull())
			{
				onWaitComplete();
			}
		}	
	}
	
	private void onAttackClicked()
	{
		onActionUsed("Knight attacks!");
	}
	
	private void onMagicClicked()
	{
		onActionUsed("Knight casts Fire!");	
	}
	
	private void onHealClicked()
	{
		onActionUsed("Knight casts heal!");	
	}
	
	private void onActionUsed(string actionDescription)
	{		
		attackBtn.SetActive(false);
		magicBtn.SetActive(false);
		healBtn.SetActive(false);	
		
		showMessageOnInfoBar(actionDescription);
		
		_waiting = true;
		progressBar.SetActive(true);
		progressBar.GetComponent<ProgressBar>().resetProgress();
	}
	
	private void onWaitComplete()
	{
		attackBtn.SetActive(true);
		magicBtn.SetActive(true);
		healBtn.SetActive(true);	
		_waiting = false;
		progressBar.SetActive(false);
	}
	
	private void showMessageOnInfoBar(string info)
	{
		infoBar.SetActive(true);
		infoBar.GetComponentInChildren<TextMesh>().text = info;
	}
	
}
