using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MetaMask.Unity;
using MetaMask.Models;
using MetaMask.IO;
using MetaMask.Contracts;



public class CreatePanelController : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField campaignNameInputField;
    [SerializeField]
    private TMP_InputField campaignDescriptionInputField;
    [SerializeField]
    private TMP_InputField campaignCategoryInputField;
    [SerializeField]
    private TMP_InputField charityNameInputField;
    [SerializeField]
    private TMP_InputField endtimeInputField;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCreateCampaignButtonPressed()
    {
        PrepareTransaction();
    }

    public async void PrepareTransaction()
    {
        var wallet = MetaMaskUnity.Instance.Wallet;




        var transactionParams = new MetaMaskTransaction
        {
            To = "0x3615594d996649741018000670FF6669A4205d83",
            From = MetaMaskUnity.Instance.Wallet.SelectedAddress,
            Value = "0x0",

        };

        var request = new MetaMaskEthereumRequest
        {
            Method = "eth_sendTransaction",
            Parameters = new MetaMaskTransaction[] { transactionParams }

        };
        await wallet.Request(request);
    }
}
