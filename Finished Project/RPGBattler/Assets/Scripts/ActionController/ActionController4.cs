using UnityEngine;
using System.Collections;

public class ActionController4 : MonoBehaviour {
	
	public GameObject attackBtn;
	public GameObject magicBtn;
	public GameObject healBtn;

	public GameObject infoBar;
	
	public GameObject progressBar;

	public float actionRechargeSpeed = 0.01f;
	
	private bool _waiting = false;

	public Enemy[] enemies;
	public float attackDamage = 0.1f;
	public float magicDamage = 0.5f;
	public float healAmount = 0.2f;
	private bool _waitingForTargetToBeSelected = false;
	private string _chosenAction;
	
	public GameObject player;

	public GameObject fireParticles;
	public GameObject healParticles;

	
	void Start () 
	{
		attackBtn.GetComponent<ActionButton>().addClickHandler(onAttackClicked);
		magicBtn.GetComponent<ActionButton>().addClickHandler(onMagicClicked);
		healBtn.GetComponent<ActionButton>().addClickHandler(onHealClicked);

		foreach(Enemy enemy in enemies)
		{
			enemy.addClickHandler(onEnemyClicked);
			enemy.setPlayerAttackedFunction(onPlayerAttacked);
		}
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
		attackEnemyWithAction("Attack");
	}
	
	private void onMagicClicked()
	{
		attackEnemyWithAction("Fire");
	}

	private void attackEnemyWithAction(string actionName)
	{
		showMessageOnInfoBar("Select target");
		_waitingForTargetToBeSelected = true;
		_chosenAction = actionName;
	}
	
	private void onHealClicked()
	{
		onActionUsed("Knight casts heal!");	
		player.GetComponent<Damageable>().adjustHealth(healAmount);
		Instantiate(healParticles,player.transform.position,Quaternion.identity);
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

	private void onEnemyClicked(Enemy enemy)
	{
		if(_waitingForTargetToBeSelected)
		{
			_waitingForTargetToBeSelected = false;
			if(_chosenAction == "Attack")
			{				
				enemy.damage(attackDamage);				
				onActionUsed("Knight uses attack!");
			}
			else
			{
				enemy.damage(magicDamage);				
				onActionUsed("Knight casts fire!");
				Instantiate(fireParticles,enemy.transform.position,Quaternion.identity);
			}
		}
	}

	private void onPlayerAttacked(Enemy enemy)
	{
		player.GetComponent<Damageable>().adjustHealth(-enemy.attackPower);
	}
	
}
