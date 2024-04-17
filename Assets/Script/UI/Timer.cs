using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;

    private float _time;

    public void SetTimer(float delay) => _time = delay;

    private void Update()
    {
        _time -= Time.deltaTime;
        _timer.text = Mathf.Round(_time).ToString();
    }
    public void ResetTimer(float _delay)
    {
        _time = _delay;
    }

}
