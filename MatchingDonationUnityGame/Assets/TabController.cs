using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabController : MonoBehaviour
{

    [SerializeField]
    private GameObject storeCanvas;

    [SerializeField]
    private GameObject homeCanvas;

    [SerializeField]
    private GameObject createPanel;

    [SerializeField]
    private GameObject charityCanvas;

    [SerializeField]
    private GameObject profileCanvas;



    // Start is called before the first frame update
    void Start()
    {
        homeCanvas.SetActive(true);
        storeCanvas.SetActive(false);
        charityCanvas.SetActive(false);
        profileCanvas.SetActive(false);
        createPanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnStoreButtonPressed()
    {
        homeCanvas.SetActive(false);
        storeCanvas.SetActive(true);
        charityCanvas.SetActive(false);
        profileCanvas.SetActive(false);
        createPanel.SetActive(false);
    }

    public void OnCharityButtonPressed()
    {
        homeCanvas.SetActive(false);
        storeCanvas.SetActive(false);
        charityCanvas.SetActive(true);
        profileCanvas.SetActive(false);
        createPanel.SetActive(false);
    }

    public void OnProfileButtonPressed()
    {
        homeCanvas.SetActive(false);
        storeCanvas.SetActive(false);
        charityCanvas.SetActive(false);
        profileCanvas.SetActive(true);
        createPanel.SetActive(false);
    }
    public void OnHomeButtonPressed()
    {
        homeCanvas.SetActive(true);
        storeCanvas.SetActive(false);
        charityCanvas.SetActive(false);
        profileCanvas.SetActive(false);
        createPanel.SetActive(false);
    }
    public void OnCreateButtonPressed()
    {
        createPanel.SetActive(true);
    }

    public void OnCloseCreatePanelPressed()
    {
        createPanel.SetActive(false);
    }
}
