using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageBar : MonoBehaviour

{
    private Slider slider;

    private float fillSpeed = 5f;

    [SerializeField]
    private Text currentValue;

    private void Awake() 
    {
        slider = gameObject.GetComponent<Slider>();
        slider.maxValue = Storage.Instance.maxStorageCount;
    }

    void Update()
    {
        slider.value = Mathf.Lerp(slider.value, int.Parse(currentValue.text), Time.deltaTime * fillSpeed);
    }
}
