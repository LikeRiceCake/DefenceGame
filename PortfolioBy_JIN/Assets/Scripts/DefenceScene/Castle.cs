using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour
{
    public int MaxCastleHP;
    public int CurrentCastleHP;
    public Text CastleHp;
    public Image CastleHpImage;
    public portPlayerPrefs data;

    private void Start()
    {
        MaxCastleHP = 100 + (data.CastleUp * 10);
        CurrentCastleHP = MaxCastleHP;
    }

    private void Update()
    {
        CastleHp.text = CurrentCastleHP + " / " + MaxCastleHP;
        CastleHpImage.fillAmount = (float)CurrentCastleHP / (float)MaxCastleHP;
    }
}
