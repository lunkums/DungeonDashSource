using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class EnsureAspectRatio : MonoBehaviour
{
    private readonly float targetAspect = 16.0f/9.0f;
    private Vector2Int resolution;
    [SerializeField] private PixelPerfectCamera pixelPerfectCamera;

    private void Awake()
    {
        resolution = new Vector2Int(Screen.width, Screen.height);
    }

    private void Update()
    {
        if (resolution.x != Screen.width || resolution.y != Screen.height)
        {
            resolution.x = Screen.width;
            resolution.y = Screen.height;
            var windowAspect = (float)resolution.x / resolution.y;
            var scaleheight = windowAspect / targetAspect;
            var cropFrame = PixelPerfectCamera.CropFrame.None;

            if (scaleheight < 1.0f)
                cropFrame = PixelPerfectCamera.CropFrame.Letterbox;
            else if (scaleheight > 1.0f)
                //cropFrame = PixelPerfectCamera.CropFrame.Pillarbox;

            pixelPerfectCamera.cropFrame = cropFrame;
        }
    }
}
