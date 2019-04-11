using UnityEngine;

namespace ColorSwitch
{
    public class FollowPlayer : MonoBehaviour
    {
        public GameObject player;
        public bool playerVisible;
        public void Start()
        {
            player = GameObject.Find("Player");
        }
        void Update()
        {
            if (!player)
                return;

            Vector3 camPos = transform.position;
            Vector3 playerPos = player.transform.position;
            Vector3 cam = Camera.main.WorldToScreenPoint(playerPos);


            if (playerPos.y > camPos.y)
            {


                playerVisible = true;
                transform.position = new Vector3(camPos.x, playerPos.y, camPos.z);
            }




            if (cam.y < playerPos.y)
            {

                playerVisible = false;
                Destroy(player.gameObject);
                Debug.Log("Death");

            }
        }
    }
}
