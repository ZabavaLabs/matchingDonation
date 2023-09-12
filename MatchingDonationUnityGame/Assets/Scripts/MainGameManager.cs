using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager Instance;

    public int karma = 0;

    [SerializeField]
    private AudioClip donateClip;

    private AudioSource audioSource;


    [SerializeField]
    private TextMeshProUGUI karmaText;
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

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SuccessfulDonation()
    {
        karma += 10;
        karmaText.text = $"{karma} K";

        audioSource.PlayOneShot(donateClip);
    }
}
