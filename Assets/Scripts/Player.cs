using UnityEngine;
using UnityEngine.Events;

namespace ColorSwitch
{
    public class Player : MonoBehaviour
    {
        public float jumpForce = 10f;

        public Rigidbody2D rigid;
        public SpriteRenderer rend;

        public Color[] colors = new Color[4];

        public UnityEvent onGameOver;
        private ScoreUI scoreCount;
        void Start()
        {
            RandomizeColor();
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
            {
                rigid.velocity = Vector2.up * jumpForce;
            }
        }

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.name == "ColorChanger")
            {
                RandomizeColor();
                Destroy(col.gameObject);
                return;
            }

            if (col.name == "Star")
            {
                // Add score
                GameManager.Instance.AddScore(1);
                Destroy(col.gameObject);
                return;
            }

            SpriteRenderer spriteRend = col.GetComponent<SpriteRenderer>();
            if (spriteRend != null &&
               spriteRend.color != rend.color)
            {
                Debug.Log("GAME OVER!");
                onGameOver.Invoke();
                //DestroyPlayer();
            }
        }

        Color GetRandomColor()
        {
            int index = Random.Range(0, 4);
            return colors[index];
        }

        void RandomizeColor()
        {
            // Generate a random color
            Color randomColor = GetRandomColor();
            // While randomColor is the same as current color
            while(rend.color == randomColor)
            {
                // Generate new randomColor
                randomColor = GetRandomColor();
            }

            // Apply color to renderer
            rend.color = randomColor;
            //currentColor = colors[index];

            
        }
        void DestroyPlayer()
        {
            Destroy(gameObject);
        }
    }
}