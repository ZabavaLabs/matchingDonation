using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MetaMask.Unity;
using MetaMask.Models;
using MetaMask.IO;
using MetaMask.Contracts;
using Nethereum.ABI;
using Nethereum.Util;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Hex;
using Nethereum.Web3;

using Nethereum.Hex.HexConvertors.Extensions;

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

        var web3 = new Web3("https://mainnet.infura.io");
        string abi = "TO BE CHANGED";
        var contract = web3.Eth.GetContract(abi, "0x3615594d996649741018000670FF6669A4205d83");
        var function = contract.GetFunction("getCollectibleDetails");


        var abiEncode = new ABIEncode();
        var data = abiEncode.GetABIEncoded(new ABIValue("bytes32", "hello"), new ABIValue("uint", 69),
                        new ABIValue("string", "world")).ToHex();


        var transactionParams = new MetaMaskTransaction
        {
            To = "0x3615594d996649741018000670FF6669A4205d83",
            From = MetaMaskUnity.Instance.Wallet.SelectedAddress,
            Value = "0x0",
            Data = data
        };

        var request = new MetaMaskEthereumRequest
        {
            Method = "eth_sendTransaction",
            Parameters = new MetaMaskTransaction[] { transactionParams }

        };
        await wallet.Request(request);
    }
}
