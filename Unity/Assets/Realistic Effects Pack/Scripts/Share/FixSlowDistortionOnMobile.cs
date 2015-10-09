using UnityEngine;

public class FixSlowDistortionOnMobile: MonoBehaviour
{
  void OnRenderImage(RenderTexture src, RenderTexture dest)
  {
    Graphics.Blit(src, dest);
  }
}