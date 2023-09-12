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
using System;
using System.Numerics;
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

    private string createContractAbi;
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
        Debug.Log("OnCreateCampaignButtonPressed");
        string campaignCategory = campaignCategoryInputField.text;

        string campaignName = campaignNameInputField.text;
        string campaignDescription = campaignDescriptionInputField.text;
        string charityName = charityNameInputField.text;
        string endTime = endtimeInputField.text;

        DateTime dateTime = DateTime.ParseExact(endTime, "yyyy-MM-dd", null);
        DateTimeOffset dateTimeOffset = new DateTimeOffset(dateTime);
        BigInteger endUnixTimestamp = dateTimeOffset.ToUnixTimeSeconds();


        SCManager.Instance.CreateCampaign(campaignCategory, campaignName, campaignDescription, charityName, endUnixTimestamp);
    }


}
