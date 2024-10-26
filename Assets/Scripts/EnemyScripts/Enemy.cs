using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(EnemyMover))]
public class Enemy : MonoBehaviour
{
	private EnemyMover _mover;
	private SpriteRenderer _sprite;
	private bool _isFlipped;

	private void Awake()
	{
		_mover = GetComponent<EnemyMover>();
		_sprite = GetComponentInChildren<SpriteRenderer>();

		_isFlipped = _sprite.flipX;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.TryGetComponent(out Border _))
			ChangeDirection();
	}

	private void ChangeDirection()
	{
		_mover.ChangeDirecton();

		if (_isFlipped)
			_sprite.flipX = false;
		else
			_sprite.flipX = true;

		_isFlipped = _sprite.flipX;
	}
}
