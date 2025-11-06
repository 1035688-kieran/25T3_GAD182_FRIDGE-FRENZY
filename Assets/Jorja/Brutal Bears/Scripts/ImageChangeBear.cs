using UnityEngine;
using UnityEngine.UI;

public class ImageChangeBear : MonoBehaviour
{
    public Image fullBear;
    public Sprite leftEar;
    public Sprite rightEar;
    public Sprite leftArm;
    public Sprite rightArm;
    public Sprite leftLeg;
    public Sprite rightLeg;
    public Sprite body;

    public void ImageChangeleftEar()
    {
        fullBear.sprite = leftEar;
    }

    public void ImageChangeRightEar()
    {
        fullBear.sprite = rightEar;
    }

    public void ImageChangeLeftArm()
    {
        fullBear.sprite = leftArm;
    }

    public void ImageChangeRigthArm()
    {
        fullBear.sprite = rightArm;
    }

    public void ImageChangeLeftLeg()
    {
        fullBear.sprite = leftLeg;
    }

    public void ImageChangeRigthLeg()
    {
        fullBear.sprite = rightLeg;
    }

    public void ImageChangeBody()
    {
        fullBear.sprite = body;
    }
}
