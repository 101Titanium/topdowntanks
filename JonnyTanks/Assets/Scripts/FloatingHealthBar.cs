using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private Camera cameraa;
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

    private void Awake()
    {
        cameraa = Camera.FindObjectOfType<Camera>();
    }
    void Start()
    {
        offset = new Vector3(0, offsetNumber, 0);

        string selectedTag = colorFirePointTags[(int)pickedColor];

        Player = GameObject.FindGameObjectWithTag(selectedTag);


    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        target.position = Player.transform.position;

        transform.rotation = cameraa.transform.rotation;
        transform.position = target.position + offset;
    }
}
