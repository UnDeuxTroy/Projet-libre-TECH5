using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    [SerializeField][Range(1, 20)]
    private float speed = 10;

    private Vector3 targetPosition;
    private bool isMoving;
    private Animator soldierAC;


	// Use this for initialization
	void Start () {
        soldierAC = this.GetComponent<Animator>();
        targetPosition = transform.position;
        isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(1))
            SetTargetPosition();
        if (isMoving)
            MovePlayer();
	
	}

    void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        isMoving = true;
    }

    void MovePlayer()
    {
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        soldierAC.SetBool("IsCharging", true);
        if (transform.position == targetPosition)
        {
            isMoving = false;
            soldierAC.SetBool("IsCharging", false);
        }
    }
}
