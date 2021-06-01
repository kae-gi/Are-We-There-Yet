using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public GameObject car;
    public TextMeshProUGUI coinCountText;

    public  TextMeshProUGUI redCostText;
    public  Image redCoin;
    private static int redCost = 25;

    public  TextMeshProUGUI greenCostText;
    public  Image greenCoin;
    private static int greenCost = 50;

    public  TextMeshProUGUI blackCostText;
    public  Image blackCoin;
    private static int blackCost = 75;

    public AudioSource clickAudio;
    public AudioSource newPurchaseAudio;
    public AudioSource insufficientAudio;

    private Color RED   = new Color(1.0f, 0.0f, 0.0f);
    private Color GREEN = new Color(0.0f, 1.0f, 0.0f);
    private Color BLACK = new Color(0.0f, 0.0f, 0.0f);
    private Color WHITE = new Color(1.0f, 1.0f, 1.0f);
    private TextMeshProUGUI lastRedText = null;

    private void Start()
    {
        coinCountText.text = GlobalData.coinCount.ToString();
        setCostText(redCost, ref redCostText, ref redCoin);
        setCostText(greenCost, ref greenCostText, ref greenCoin);
        setCostText(blackCost, ref blackCostText, ref blackCoin);
        updateStoreSceneCarColor(GlobalData.carColor);
    }

    public void setCostText(int cost, ref TextMeshProUGUI t, ref Image coin)
    {
        if (cost > 0)
        {
            t.text = cost.ToString();
        }
        else
        {
            t.text = "";
            coin.enabled = false;
        }
    }

    public void updateStoreSceneCarColor(Color color)
    {
        car.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = color;
    }

    private void makeTextRed(TextMeshProUGUI text)
    {
        if (lastRedText)
        {
            lastRedText.color = WHITE;
        }
        lastRedText = text;
        text.color = RED;
    }

    private void makeLastTextWhite()
    {
        if (lastRedText)
        {
            lastRedText.color = WHITE;
        }
    }

    private void makePurchase(ref int cost, ref TextMeshProUGUI t, ref Image i)
    {
        GlobalData.coinCount -= cost;
        coinCountText.text = GlobalData.coinCount.ToString();
        cost = 0;
        t.text = "";
        newPurchaseAudio.Play();
        i.enabled = false;
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void bluePaint()
    {
        clickAudio.Play();
        GlobalData.carColor = WHITE; // the base coat is already blue, so just use white
        updateStoreSceneCarColor(GlobalData.carColor);
        makeLastTextWhite();
    }

    public void redPaint()
    {
        // return if the player doesn't have enough coins
        if (GlobalData.coinCount < redCost)
        {
            insufficientAudio.Play();
            makeTextRed(redCostText);
            return;
        }
        redCostText.color = WHITE;

        // purchase if able to
        if (GlobalData.coinCount >= redCost && redCost > 0)
        {
            makePurchase(ref redCost, ref redCostText, ref redCoin);
        }
        else
        {
            clickAudio.Play();
        }

        makeLastTextWhite();
        // set the car color
        GlobalData.carColor = RED;
        updateStoreSceneCarColor(GlobalData.carColor);
    }

    public void greenPaint()
    {
        // return if the player doesn't have enough coins
        if (GlobalData.coinCount < greenCost)
        {
            insufficientAudio.Play();
            makeTextRed(greenCostText);
            return;
        }
        greenCostText.color = WHITE;

        // purchase if able to
        if (GlobalData.coinCount >= greenCost && greenCost > 0)
        {
            makePurchase(ref greenCost, ref greenCostText, ref greenCoin);
        }
        else
        {
            clickAudio.Play();
        }

        makeLastTextWhite();
        // set the car color
        GlobalData.carColor = GREEN;
        updateStoreSceneCarColor(GlobalData.carColor);
    }

    public void blackPaint()
    {
        // return if the player doesn't have enough coins
        if (GlobalData.coinCount < blackCost)
        {
            insufficientAudio.Play();
            makeTextRed(blackCostText);
            return;
        }
        blackCostText.color = WHITE;

        // purchase if able to
        if (GlobalData.coinCount >= blackCost && blackCost > 0)
        {
            makePurchase(ref blackCost, ref blackCostText, ref blackCoin);
        }
        else
        {
            clickAudio.Play();
        }

        makeLastTextWhite();
        // set the car color
        GlobalData.carColor = BLACK;
        updateStoreSceneCarColor(GlobalData.carColor);
    }
}
