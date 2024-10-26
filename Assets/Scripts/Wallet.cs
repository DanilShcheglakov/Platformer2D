using UnityEngine;

public class Wallet : MonoBehaviour
{
	[SerializeField] private Player _player;

	public int Amaunt { get; private set; } = 0;

	private void OnEnable()
	{
		_player.PickUpedCoin += AddCoin;
	}

	private void OnDisable()
	{
		_player.PickUpedCoin -= AddCoin;
	}

	private void AddCoin()
	{
		Amaunt++;

		Debug.Log("Δενόγθ: " + Amaunt);
	}
}
