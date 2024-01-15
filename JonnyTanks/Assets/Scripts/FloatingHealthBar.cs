using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private GameObject ccamera;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject Player;
    private Vector3 offset;
    public float offsetNumber = 0.75f;

    public string[] colorFirePointTags = { "GreenPlayer", "BluePlayer", "RedPlayer", "SandPlayer", "BlackPlayer" };

    [SerializeField] private PlayerColor pickedColor;
    public enum PlayerColor
    {
        GreenPlayer,
        BluePlayer,
        RedPlayer,
        SandPlayer,
        BlackPlayer,
    }

    void Start()
    {
        offset = new Vector3(0, offsetNumber, 0);

        string selectedTag = colorFirePointTags[(int)pickedColor];

        Player = GameObject.FindGameObjectWithTag(selectedTag);

        ccamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        target.position = Player.transform.position;

        transform.rotation = ccamera.transform.rotation;
        transform.position = target.position + offset;
    }
}
