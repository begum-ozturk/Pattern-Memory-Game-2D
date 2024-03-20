using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuButton : MonoBehaviour
{
    public Button[] menuButtons;
    private Color[] rainbowColors = {Color.red, Color.magenta, Color.blue, Color.cyan, Color.green, Color.yellow};
    private int currentButtonIndex = 0;

    void Start(){
        StartCoroutine(ChangeButtonColors());
    }

    IEnumerator ChangeButtonColors(){
        while(true){
            ColorBlock originalColors = menuButtons[currentButtonIndex].colors;
            ColorBlock newColors = originalColors;
            newColors.normalColor = new Color(rainbowColors[currentButtonIndex % rainbowColors.Length].r, rainbowColors[currentButtonIndex % rainbowColors.Length].g, rainbowColors[currentButtonIndex % rainbowColors.Length].b, 0.8f);
            menuButtons[currentButtonIndex].colors = newColors;

            yield return new WaitForSeconds(1);

            menuButtons[currentButtonIndex].colors = originalColors;
            currentButtonIndex = (currentButtonIndex + 1) % menuButtons.Length;
        }
    }
}
