
using TMPro;
using UnityEngine;

public class Point : MonoBehaviour
{
    [SerializeField] private PointData pointData;
    [SerializeField] private PointData nextPoint;
    [SerializeField] private TMP_Text textTime;
    private float timeForArrive;
    private string textTimeNextPoint;

    public float TimeForArrive => pointData.TimeForArrive;
    public Vector3 Position => pointData.Position;

    private void Start()
    {
        timeForArrive = pointData.TimeForArrive;
        transform.position = pointData.Position;
        textTimeNextPoint = nextPoint.TimeForArrive.ToString()  ;
        textTime.text = textTimeNextPoint;

    }
}
