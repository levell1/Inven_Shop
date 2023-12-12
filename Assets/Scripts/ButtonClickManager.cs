using UnityEngine;

public class ButtonClickManager : MonoBehaviour
{
    public GameObject Buttons;
    public GameObject Stats;
    public GameObject Inven;
    public GameObject Shop;
    public GameObject Exitbutton;

    private void ButtonsSetFalse()
    {
        Buttons.SetActive(false);
    }
    private void ButtonsSetTrue()
    {
        Buttons.SetActive(true);
    }
    public void StatView() 
    {
        ButtonsSetFalse();
        Stats.SetActive(true);
        Exitbutton.SetActive(true);
    }
    public void InvenView()
    {
        ButtonsSetFalse();
        Inven.SetActive(true);
        Exitbutton.SetActive(true);
    }
    public void ShopView()
    {
        ButtonsSetFalse();
        Shop.SetActive(true);
        Exitbutton.SetActive(true);
    }

    // 뒤로가기 버튼
    public void ExitButtonClick() 
    {
        Exitbutton.SetActive(false);
        Shop.SetActive(false);
        Inven.SetActive(false);
        Stats.SetActive(false);
        ButtonsSetTrue();
    }

}
