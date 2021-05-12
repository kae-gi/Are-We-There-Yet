using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StoreManager : MonoBehaviour
{
    public GameObject car;
    public TextMeshProUGUI coinCountText;

    public TextMeshProUGUI redCostText;
    private static int redCost = 25;

    public TextMeshProUGUI greenCostText;
    private static int greenCost = 50;

    public TextMeshProUGUI blackCostText;
    private static int blackCost = 75;

    public AudioSource clickAudio;
    public AudioSource newPurchaseAudio;
    public AudioSource insufficientAudio;

    private Color RED   = new Color(1.0f, 0.0f, 0.0f);
    private Color GREEN = new Color(0.0f, 1.0f, 0.0f);
    private Color BLACK = new Color(0.0f, 0.0f, 0.0f);
    private Color WHITE = new Color(1.0f, 1.0f, 1.0f);

    private void Start()
    {
        coinCountText.text = GlobalData.coinCount.ToString();
        redCostText.text   = redCost.ToString();
        greenCostText.text = greenCost.ToString();
        blackCostText.text = blackCost.ToString();
        updateStoreSceneCarColor(GlobalData.carColor);
    }

    public void updateStoreSceneCarColor(Color color)
    {
        car.transform.GetChild(0).GetComponent<MeshRenderer>().material.color = color;
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
    }

    public void redPaint()
    {
        // return if the player doesn't have enough coins
        if (GlobalData.coinCount < redCost)
        {
            insufficientAudio.Play();
            redCostText.color = RED;
            return;
        }
        redCostText.color = WHITE;

        // purchase if able to
        if (GlobalData.coinCount >= redCost && redCost > 0)
        {
            GlobalData.coinCount -= redCost;
            coinCountText.text = GlobalData.coinCount.ToString();
            redCost = 0;
            redCostText.text = "0";
            newPurchaseAudio.Play();
        }
        else
        {
            clickAudio.Play();
        }

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
            greenCostText.color = RED;
            return;
        }
        greenCostText.color = WHITE;

        // purchase if able to
        if (GlobalData.coinCount >= greenCost && greenCost > 0)
        {
            GlobalData.coinCount -= greenCost;
            coinCountText.text = GlobalData.coinCount.ToString();
            greenCost = 0;
            greenCostText.text = "0";
            newPurchaseAudio.Play();
        }
        else
        {
            clickAudio.Play();
        }

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
            blackCostText.color = RED;
            return;
        }
        blackCostText.color = WHITE;

        // purchase if able to
        if (GlobalData.coinCount >= blackCost && blackCost > 0)
        {
            GlobalData.coinCount -= blackCost;
            coinCountText.text = GlobalData.coinCount.ToString();
            blackCost = 0;
            blackCostText.text = "0";
            newPurchaseAudio.Play();
        }
        else
        {
            clickAudio.Play();
        }

        // set the car color
        GlobalData.carColor = BLACK;
        updateStoreSceneCarColor(GlobalData.carColor);
    }
}
