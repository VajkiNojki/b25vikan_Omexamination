using UnityEngine;

public class HideTextOnInput : MonoBehaviour
{
    [Header("Inställningar")]
    // Här väljer du vilken knapp som ska dölja texten (t.ex. A eller Space)
    public KeyCode inputKey = KeyCode.A;
    
    // Om du har en alternativ knapp (t.ex. D för att gå)
    public KeyCode secondaryInputKey = KeyCode.None;

    [Header("Referenser")]
    // Dra in den text som ska dyka upp efteråt här
    public GameObject nextText;

    void Update()
    {
        // Känner av om spelaren trycker på någon av de valda knapparna
        if (Input.GetKeyDown(inputKey) || (secondaryInputKey != KeyCode.None && Input.GetKeyDown(secondaryInputKey)))
        {
            ShowNextAndHide();
        }
    }

    private void ShowNextAndHide()
    {
        // Aktivera nästa text om en sådan är tilldelad
        if (nextText != null)
        {
            nextText.SetActive(true);
        }

        // Stäng av den nuvarande texten
        gameObject.SetActive(false);
    }
}