using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _hook;
    [SerializeField] private GameObject _linkPrefab;
    [SerializeField] private int _linkCount = 4;
    
    // Start is called before the first frame update
    private void OnEnable()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        Rigidbody2D previousRB = _hook;
        
        for (int i = 0; i < _linkCount; i++)
        {
            var link = Instantiate(_linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            previousRB = link.GetComponent<Rigidbody2D>();
        }
    }
}
