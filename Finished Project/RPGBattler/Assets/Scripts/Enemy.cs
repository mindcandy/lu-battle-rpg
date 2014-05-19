using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public delegate void EnemyDelegate(Enemy enemy);
	public float attackSpeed = 3.0f;
	public float attackPower = 0.01f;
	
	private EnemyDelegate _onEnemyClicked;
	private EnemyDelegate _onPlayerAttacked;

	void Start()
	{
		Invoke ("performAction",attackSpeed);
	}

	public void addClickHandler(EnemyDelegate onClicked)
	{
		_onEnemyClicked = onClicked;
	}

	public void setPlayerAttackedFunction(EnemyDelegate onPlayerAttacked)
	{
		_onPlayerAttacked = onPlayerAttacked;
	}

	public void damage(float amount)
	{
		GetComponent<Damageable>().adjustHealth(-amount);
	}

	public void OnMouseDown()
	{
		if(_onEnemyClicked != null)
		{
			_onEnemyClicked(this);
		}
	}

	private void performAction ()
	{
		_onPlayerAttacked(this);
		Invoke ("performAction",attackSpeed);
	}


}
