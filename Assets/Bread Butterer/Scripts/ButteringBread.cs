using UnityEngine;
using UnityEngine.Tilemaps;

public class ButteringBread : MonoBehaviour
{
    [SerializeField] SoundEffectsManager SoundsEffectsManager;

    public int timesButtered = 0;

    [SerializeField] GameObject ButteredSectionBread;
    [SerializeField] GameObject ButteredSectionBread1;
    [SerializeField] GameObject ButteredSectionBread2;

    public Tile butteredBread;

    public Vector3Int position;

    public Tilemap tilemap;
    [ContextMenu("Paint")]

    void Start()
    {
        ButteredSectionBread.SetActive(false);
        ButteredSectionBread1.SetActive(false);
        ButteredSectionBread2.SetActive(false);
    }

    public void ButtonPressed()
    {
        SoundsEffectsManager.GetComponent<SoundEffectsManager>().Play();

        timesButtered += 1;


        if (timesButtered == 1)
        {
            ButteredSectionBread.SetActive(true);
        }

        if (timesButtered == 3)
        {
            ButteredSectionBread1.SetActive(true);
        }

        if (timesButtered == 4)
        {
            ButteredSectionBread2.SetActive(true);
        }

        if (timesButtered == 5)
        {
            ButteredSectionBread.SetActive(false);
            ButteredSectionBread1.SetActive(false);
            ButteredSectionBread2.SetActive(false);

            Paint();
        }
    }

    public void Paint()
    {
        tilemap.SetTile(position, butteredBread);
    }

}
