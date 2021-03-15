using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SobrietyBar : MonoBehaviour
{

    public Slider sobrietyBar;

    public Sobriety sobriety;

    // Start is called before the first frame update
    void Start()
    {
        sobriety = GameObject.FindGameObjectWithTag("Player").GetComponent<Sobriety>();
        sobrietyBar = GetComponent<Slider>();
        sobrietyBar.maxValue = sobriety.maxSobriety;
        sobrietyBar.value = sobriety.curSobriety;
    }

    private void Update()
    {
        
    }

    public void SetSobriety()
    {
        sobrietyBar.value += 1;
    }
    public void Sobering()
    {
        sobrietyBar.value -= 1;
    }

    

}
