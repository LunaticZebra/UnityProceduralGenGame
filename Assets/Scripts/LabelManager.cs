using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelManager : MonoBehaviour
{
    private static TMPro.TextMeshPro textMeshPro;
    private void Awake()
    {
        textMeshPro = gameObject.GetComponent<TMPro.TextMeshPro>();
    }
    
    public static void UpdateLabelValue()
    {
        textMeshPro.text = "Wrogowie:" + GameStateManager.GetNumberOfEnemies();
    }

}
