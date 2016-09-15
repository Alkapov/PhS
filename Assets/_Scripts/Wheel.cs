using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour
{

    public Transform wheel;
    /// <summary>
    /// Слайдер радиус 0.1 до 1 (дефолт 0.3)
    /// Вывод радиуса
    /// </summary>
    public float radius = 1;
    /// <summary>
    /// Вывод частоты
    /// Слайдер 0 - 100, шаг 1
    /// </summary>
    public float wheel_frequency;

    public GameObject blackout;
    /// <summary>
    /// Вывод
    /// Слайдер 0-100, 1000, 1
    /// </summary>
    public float stroboscope_frequency;
    private float stroboscope_period, stroboscope_time;

    private float flash_time = 0.05f;

    /// <summary>
    /// Вывод скорости
    /// </summary>
    public float Velocity
    {
        get
        {
            float f = radius * 360 * wheel_frequency;
            return f;
        }
    }



    void Start()
    {
        //QualitySettings.vSyncCount = 2;
        //Application.targetFrameRate = 30;
    }


    void FixedUpdate()
    {
        wheel.Rotate(0, 0, -wheel_frequency * 360 * 0.02f);
    }

    void Update()
    {
        stroboscope_period = 1 / stroboscope_frequency;

        stroboscope_time += Time.deltaTime;
        blackout.SetActive(true);
        if (stroboscope_time > stroboscope_period)
        {
            blackout.SetActive(false);
            stroboscope_time = 0;
            //flash_time -= Time.deltaTime;
            //if (flash_time < 0)
            //{
            //    stroboscope_time = 0;
            //    flash_time = 0.05f;
            //    blackout.SetActive(true);
            //}
        }
    }
}
