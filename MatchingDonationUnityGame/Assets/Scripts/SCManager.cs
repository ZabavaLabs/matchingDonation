using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using System.IO;
using MetaMask.Unity;
using MetaMask.Models;
using MetaMask.IO;
using MetaMask.Contracts;
using Nethereum.ABI;
using Nethereum.Util;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Contracts;
using Nethereum.Contracts.Standards;
using Nethereum.ABI.Encoders;
using Nethereum.RPC.Eth.DTOs;
using System;

using MetaMask.Contracts;


public class SCManager : MonoBehaviour
{

    public static SCManager Instance;

    public event EventHandler onTransactionSent;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {

    }
    public void CreateCampaign(string category, string programName, string programDescription, string recipientName, BigInteger endTime)
    {
        PrepareTransaction(category, programName, programDescription, recipientName, endTime);
    }

    public async void PrepareTransaction(string category, string programName, string programDescription, string recipientName, BigInteger endTime)
    {
        Debug.Log("PrepareTransaction");
        var wallet = MetaMaskUnity.Instance.Wallet;

        var web3 = new Web3("https://rpc.testnet.mantle.xyz");
        //This line is causing some errors in Unity.
        //Contract contract = web3.Eth.GetContract(Constants.FACTORY_ABI, Constants.FACTORY_ADDRESS);
        //TransactionInput transactionInput = contract.GetFunction("CreateNewProgram").CreateTransactionInput(wallet.SelectedAddress, category, programName, programDescription, wallet.SelectedAddress, recipientName, endTime);


        // 0xdb29dda1
        Debug.Log("Wallet Selected Address");
        Debug.Log(wallet.SelectedAddress);
        Debug.Log("EndTime");
        Debug.Log(endTime);

        var transactionParams = new MetaMaskTransaction
        {
            To = MetaMaskUnity.Instance.Wallet.SelectedAddress,
            From = MetaMaskUnity.Instance.Wallet.SelectedAddress,
            Value = "0x0",
            //Data = transactionInput.Data,

            ChainId = "5001"
        };
        Debug.Log("Request");

        var request = new MetaMaskEthereumRequest
        {
            Method = "eth_sendTransaction",
            Parameters = new MetaMaskTransaction[] { transactionParams }

        };

        onTransactionSent?.Invoke(this, EventArgs.Empty);

        var res = await wallet.Request(request);
        Debug.Log("Response");
        Debug.Log(res);

    }

    public async void DonateTransaction()
    {
        var wallet = MetaMaskUnity.Instance.Wallet;

        

        // 0xdb29dda1
        Debug.Log("Wallet Selected Address");
        Debug.Log(wallet.SelectedAddress);
        Debug.Log("EndTime");
        

        var transactionParams = new MetaMaskTransaction
        {
            To = "0x4156EDbAFC5091507dE2dD2a53dEd551a346f83b",
            From = MetaMaskUnity.Instance.Wallet.SelectedAddress,
            Value = "0x0",
            //Data = transactionInput.Data,

            ChainId = "5001"
        };
        Debug.Log("Request");

        var request = new MetaMaskEthereumRequest
        {
            Method = "eth_sendTransaction",
            Parameters = new MetaMaskTransaction[] { transactionParams }

        };

        onTransactionSent?.Invoke(this, EventArgs.Empty);

        var res = await wallet.Request(request);
        Debug.Log("Response");
        Debug.Log(res);
    }
}
