
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "PointData", menuName = "ScriptableObjects/PointData", order = 1)]
public class PointData : ScriptableObject
{
    [SerializeField] private float timeForArrive;

    [SerializeField] private Vector3 position; 

    public float TimeForArrive => timeForArrive;
    public Vector3 Position => position;


}
