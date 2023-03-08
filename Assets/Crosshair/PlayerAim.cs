using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    //Cam Variables
    public float fixedRadius = 5f;

    public Camera playerCamera;
    public GameObject targetIndicatorPrefab;
    
    //Private Variables
    Rigidbody r;
    GameObject targetObject;

    //Mouse cursor camera offset effect
    Vector2 playerPosOnScreen;
    Vector2 cursorPosition;
    Vector2 offsetVector;

    //Plane that represents imaginary floor that will be used to calculate Aim target position
    Plane surfacePlane = new Plane();

    void Awake()
    {
        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;

        //Instantiate aim target prefab
        if(targetIndicatorPrefab)
        {
            targetObject = Instantiate(targetIndicatorPrefab , Vector3.zero , Quaternion.identity) as GameObject;
        }

        //Hides cursor
        Cursor.visible = false;
    }

    void FixedUpdate()
    {
        


        //Mouse cursor offset effect
        playerPosOnScreen = playerCamera.WorldToViewportPoint(transform.position);
        cursorPosition = playerCamera.ScreenToViewportPoint(Input.mousePosition);
        offsetVector = cursorPosition - playerPosOnScreen;

        

        //Aim target position and rotation
        targetObject.transform.position = GetAimTargetPos();
        targetObject.transform.LookAt(new Vector3 (transform.position.x , targetObject.transform.position.y , transform.position.z));

        //Player rotation
        transform.LookAt(new Vector3 (targetObject.transform.position.x , transform.position.y , targetObject.transform.position.z));
    }

   Vector3 GetAimTargetPos()
{
    //Update surface plane
    surfacePlane.SetNormalAndPosition(Vector3.up , transform.position);

    //Create a ray from mouse click position
    Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

    //Initialise the enter variable
    float enter = 0.0f;

    if(surfacePlane.Raycast(ray , out enter))
    {
        //Get the point that is clicked
        Vector3 hitPoint = ray.GetPoint(enter);

        //Calculate the direction vector from player to aim target
        Vector3 direction = hitPoint - transform.position;

        //Set the distance from the player to aim target
        float distance = Mathf.Clamp(direction.magnitude, 0f, fixedRadius);

        //Normalize the direction vector and multiply it by the fixed radius
        direction.Normalize();
        direction *= distance;

        //Add the player's position to the direction vector to get the final aim target position
        Vector3 aimTargetPos = transform.position + direction;

        //Move the aim indicator prefab to the aim target position
        if(targetObject != null)
        {
            targetObject.transform.position = aimTargetPos;
        }

        return aimTargetPos;
    }

    return new Vector3 (-5000 , - 5000, -5000);
}

}
