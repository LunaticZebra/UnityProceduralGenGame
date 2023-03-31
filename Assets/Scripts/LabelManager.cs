using UnityEngine;
using TMPro;

public class LabelManager : MonoBehaviour
{
    private static TextMeshProUGUI _textMeshPro;
    private void Awake()
    {
        _textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        print(_textMeshPro==null);
    }
    
    public static void ChangeLabelValue(int number)
    {
        Debug.Log("CHANGED TO -" + number);
        _textMeshPro.text = "Wrogowie:" + number;
    }

}
