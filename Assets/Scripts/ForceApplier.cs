using UnityEngine;

public class ForceApplier : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rigidBody;
	[SerializeField] private float _forceStrength = 100f;
	
	public void ApplyRandomForce()
	{
		var xDirection = Random.Range(-1f, 1f);
		var yDirection = Random.Range(-1f, 1f);

		var directionVector = new Vector2(xDirection, yDirection);
		directionVector.Normalize();
		_rigidBody.AddForce(directionVector * _forceStrength, ForceMode2D.Impulse);
	}
}
