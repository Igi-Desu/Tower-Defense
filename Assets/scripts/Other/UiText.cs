using UnityEngine;
using UnityEngine.UI;

public class UiText : MonoBehaviour
{
    // Start is called before the first frame update
    public string text{
        set { GetComponent<Text>().text = value; }
    }
}
