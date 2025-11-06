using UnityEngine;
using UnityEngine.UI;

public class ChangeImage : MonoBehaviour
{
    public Image closedPea;
    public Sprite onePeaOut;
    public Sprite twoPeasOut;
    public Sprite threePeasOut;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
