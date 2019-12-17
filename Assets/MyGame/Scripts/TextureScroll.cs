using UnityEngine;

public class TextureScroll : MonoBehaviour
{
    public float scrollSpeed;
    public bool scrollBackground = true;
    private Material backgroundMaterial;

    // Called once on gamestart, sets backgroundmaterial
    private void Awake()
    {
        backgroundMaterial = GetComponent<Renderer>().material;
    }

    // Called every fixed framerate frame, scrolls the background
    private void FixedUpdate()
    {
        if (scrollBackground)
        {
            Vector2 offset = new Vector2(scrollSpeed * Time.time, 0f);
            backgroundMaterial.mainTextureOffset = offset;
        }
    }
}
