using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image closedPea;
    public Sprite onePeaOut;
    public Sprite twoPeasOut;
    public Sprite threePeasOut;

    public void ImageChangePea1()
    {
        closedPea.sprite = onePeaOut;
    }

    public void ImageChangePea2()
    {
        closedPea.sprite = twoPeasOut;
    }

    public void ImageChangePea3()
    {
        closedPea.sprite = threePeasOut;
    }

}
