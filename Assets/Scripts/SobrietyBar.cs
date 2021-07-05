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
        sobriety = GameObject.FindGameObjectWithTag("Player").GetComponent<Sobriety>(); // Gets the sobriety script off the player
        sobrietyBar = GetComponent<Slider>(); // Sets the slider component 
        sobrietyBar.maxValue = sobriety.maxSobriety; // Sets max value to sobriety max value
        sobrietyBar.value = sobriety.curSobriety; // the bar value equals the current sobriety
    }

    private void Update()
    {
        
    }

    public void SetSobriety()
    {
        sobrietyBar.value += 1; // Adds one sobriety when the player jumps on a block
    }
    public void Sobering() // minus one if the player hits water block.
    {
        sobrietyBar.value -= 1;
    }

    

}
