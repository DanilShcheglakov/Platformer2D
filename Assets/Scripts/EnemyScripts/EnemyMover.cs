using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMover : MonoBehaviour
{
	private Rigidbody2D _rb;

	[SerializeField] private float _enemySpeed;

	private void Awake()
	{
		_rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		ChangePosition();
	}

	public void ChangeDirecton()
	{
		_enemySpeed *= -1;
	}

	private void ChangePosition()
	{
		_rb.velocity = new Vector2(_enemySpeed * Time.fixedDeltaTime, _rb.velocity.y);
	}
}
