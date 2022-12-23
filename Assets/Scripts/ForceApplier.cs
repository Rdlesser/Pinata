using UnityEngine;

public class ForceApplier : MonoBehaviour
{
	[SerializeField] private Rigidbody2D _rigidBody;
	[SerializeField] private float _forceStrength = 100f;
	[SerializeField] private Vector2 _xDirectionRange;
	[SerializeField] private Vector2 _yDirectionRange;
	
	public void ApplyRandomForce()
	{
		var xDirection = Random.Range(_xDirectionRange.x, _xDirectionRange.y);
		var yDirection = Random.Range(_yDirectionRange.x, _yDirectionRange.y);

		var directionVector = new Vector2(xDirection, yDirection);
		directionVector.Normalize();
		_rigidBody.AddForce(directionVector * _forceStrength, ForceMode2D.Impulse);
	}
}
