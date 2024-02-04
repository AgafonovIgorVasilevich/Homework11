using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class HealthViewSmooth : HealthView
{
    [SerializeField] private float _speedChanging = 1;
    [SerializeField] private Image _image;

    private bool _inProgress = false;
    private float _currentValue;

    public override void Show(int current, int max)
    {
        _currentValue = (float)current / max;

        if (_inProgress == false)
            StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        _inProgress = true;

        while (_image.fillAmount != _currentValue)
        {
            _image.fillAmount = Mathf.MoveTowards(
                _image.fillAmount, _currentValue,
                _speedChanging * Time.deltaTime);
            yield return null;
        }

        _inProgress = false;
    }
}