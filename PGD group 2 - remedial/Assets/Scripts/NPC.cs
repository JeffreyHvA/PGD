using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
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
       if (hit.transform != null)
                 {
                     CurrentClickedGameObject(hit.transform.gameObject);
                 }

     }
   }  

    bool PlayerInRange()
        {
            return Vector3.Distance(player.transform.localPosition, transform.localPosition) < range;
        }

    void CurrentClickedGameObject(GameObject gameObject)
    {
     if(gameObject.tag=="NPC")
     {
          Debug.Log("Hello, I'm an NPC");
     }
    }

 }
}
