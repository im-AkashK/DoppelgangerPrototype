using UnityEngine;

public class Look : MonoBehaviour
{
    
    

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray , out hit))
        {
            transform.LookAt(new Vector3 (hit.point.x , transform.position.y , hit.point.z));
        }
    }
}

