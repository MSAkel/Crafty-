using UnityEngine;
using UnityEngine.UI;

public class ClosePanel : MonoBehaviour
{
    void Start()
    {
    gameObject.GetComponent<Button>().onClick.AddListener(HandleClosing);
  }

  private void HandleClosing()
  {
    gameObject.transform.parent.gameObject.GetComponent<CanvasGroup>().transform.localScale = new Vector3(0, 0, 0);
    GameObject.Find("UIButtons").GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
    GameObject.Find("CurrenciesBar").GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
  }
}
