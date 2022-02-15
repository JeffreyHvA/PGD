using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3 : MonoBehaviour
{
    // Start is called before the first frame update
     public Player player;
    public float range;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetMouseButtonDown(0))
     {
     Ray ray =  Camera.main.ScreenPointToRay (Input.mousePosition);
     RaycastHit hit;

     if (Physics.Raycast(ray, out hit) &&  PlayerInRange())
     {
        Debug.Log("Hello3");

     }
   }  

    bool PlayerInRange()
        {
            return Vector3.Distance(player.transform.localPosition, transform.localPosition) < range;
        }
    }
}
