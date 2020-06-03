using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Tiling : MonoBehaviour {

    public float offsetX = 5;

    public bool hasRightBuddy = false;
    public bool hasLeftBuddy = false;
    public float speed;

    private Camera p_cam;
    private Transform p_myTransform;

    private float p_spriteWidth;
    private Vector3 p_spriteScale;

    private void Awake() {
        p_cam = Camera.main;
        p_myTransform = this.transform;
    }

    // Start is called before the first frame update
    void Start() {
        SpriteRenderer sRenderer = GetComponent<SpriteRenderer>();
        p_spriteWidth = sRenderer.sprite.bounds.size.x;
        p_spriteScale = p_myTransform.localScale;
    }

    // Update is called once per frame
    void Update() {
        // Translates the tile to the right
        p_myTransform.position = new Vector3(p_myTransform.position.x + speed, p_myTransform.position.y, p_myTransform.position.z);

        if (hasLeftBuddy == false) {
            // calculate the camera's extend (half the width) of what the camera can see in world coord
            float camHorizontalExtend = p_cam.orthographicSize * Screen.width / Screen.height;

            // calcualte the x pos where the camera can see the edge of the sprite (element)
            //float edgeVisiblePosRight = (p_myTransform.position.x + p_spriteWidth / 2) - camHorizontalExtend;
            float edgeVisiblePosLeft = (p_myTransform.position.x - p_spriteWidth / 2) + camHorizontalExtend;

            // used to calculate if the transform is passed the middle of the camera
            /*
            if (p_cam.transform.position.x >= edgeVisiblePosRight - offsetX && hasRightBuddy == false) {
                MakeNewBuddy(1);
                hasRightBuddy = true;
            } else if (p_cam.transform.position.x <= edgeVisiblePosLeft + offsetX && hasLeftBuddy == false) {
                MakeNewBuddy(-1);
                hasLeftBuddy = true;
            }
            */

            if (p_cam.transform.position.x <= edgeVisiblePosLeft + offsetX && hasLeftBuddy == false) {
                MakeNewBuddy(-1);
                hasLeftBuddy = true;
            }
        }

        // Check if the tile has moved off the screen
        CheckBounds();
    }

    // Makes a new buddy
    // rightOrLeft determines the side for which a new buddy is created
    public void MakeNewBuddy(int rightOrLeft) {
        Vector3 newPos = new Vector3(p_myTransform.position.x + p_spriteWidth * p_spriteScale.x * rightOrLeft, p_myTransform.position.y, p_myTransform.position.z);
        Transform newBuddy = Instantiate(p_myTransform, newPos, p_myTransform.rotation) as Transform;
        newBuddy.parent = p_myTransform.parent;
    }

    // Checks if the tile has left the screen
    public void CheckBounds() {
        float transformLeft = p_myTransform.position.x - (p_spriteWidth * p_spriteScale.x / 2);
        float camHorizontalExtend = p_cam.orthographicSize * Screen.width / Screen.height;

        if (transformLeft > p_cam.transform.position.x + camHorizontalExtend) {
            Destroy();
        }
    }

    // Destorys background tile when its no longer visible on screen
    public void Destroy() {
        // Destroys object after 1 second
        Destroy(this.gameObject, .5f);

        // maybe do something else
    }
}
