using UnityEngine;

public class ScreenToWorld : MonoBehaviour
{
    public Camera cam;

    private RaycastHit downLeftHit, downRightHit, upLeftHit, upRightHit; // Esquinas proyectadas en el mundo

    private void Start() { GetHitsFromCameraEdgesOnWorld(); }
    private void GetHitsFromCameraEdgesOnWorld()
    {
        // Esquinas de la cámara
        Vector2 downLeft  = Vector2.zero;
        Vector2 downRight = new Vector2(cam.pixelWidth, 0);
        Vector2 upLeft    = new Vector2(0, cam.pixelHeight);
        Vector2 upRight   = new Vector2(cam.pixelWidth, cam.pixelHeight);

        Ray downLeftRay  = cam.ScreenPointToRay(downLeft);
        Ray downRightRay = cam.ScreenPointToRay(downRight);
        Ray upLeftRay    = cam.ScreenPointToRay(upLeft);
        Ray upRightRay   = cam.ScreenPointToRay(upRight);

        Physics.Raycast(downLeftRay, out downLeftHit);
        Physics.Raycast(downRightRay, out downRightHit);
        Physics.Raycast(upLeftRay, out upLeftHit);
        Physics.Raycast(upRightRay, out upRightHit);
    }

    public Vector3 RandomBorderPosition()
    {
        int index = Random.Range(0, 4); // Four cardinal orientation N-S-E-W
        float t = Random.Range(0, 1f);
        Vector3 borderPos;
        switch (index)
        {
            case 0:
                borderPos = Vector3.Lerp(upLeftHit.point, upRightHit.point, t); // North
                break;
            case 1:
                borderPos = Vector3.Lerp(downLeftHit.point, downRightHit.point, t); // South
                break;
            case 2:
                borderPos = Vector3.Lerp(downLeftHit.point, upLeftHit.point, t); // East
                break;
            case 3:
                borderPos = Vector3.Lerp(upRightHit.point, downRightHit.point, t); // West
                break;
            default:
                Debug.Log("Error spawnPosition");
                borderPos = Vector3.Lerp(downLeftHit.point, upLeftHit.point, t); // East
                break;
        }
        return borderPos;
    }
}
