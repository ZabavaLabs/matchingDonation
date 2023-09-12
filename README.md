# Ethereum Singapore 2023 Hackathon

## Team Zabava Labs

![alt text](./readme_files/zabavaLogo.png)

### Members

1. Dan (Discord: @permaintern, Telegram: @permaintern, Email: dan.tgw@gmail.com)
2. Mud (Discord: @md_argv, Telegram: @md_argv, Email: mudmud.muhd@gmail.com)

## Project Submission

### Name: Karma Farmer

### Tracks Submitted For

1. Quadratic Funding: Problem Statement 1
2. Mantle Challenge Track #2
3. Metamask Challenge Track #4

### Problems

- Lack of corporate gift matching activities
- Donors are unsure if such gifting programs are trustworthy
- Non-profit has never been associated with fun, which leads to donor fatigue

### Our Solution: Karma Farmer

A casual mobile app that gamifies the charitable gifting process, so that donors are engaged, and can donate in a fun way. The goal is to accumulate as much karma as possible by donating. The top donor for a campaign will receive a soulbound token to flex. Karma points will eventually be used to buy in-game items.

![alt text](./readme_files/logo.jpg)

### Tech Stack

- Solidity, Truffle, Hardhat
- Metamask Unity SDK
- Unity

## Smart Contract Logic

Overall Flow of the Smart Contracts: (Solidity Smart Contracts are in this [folder](./contracts/))

1. Charities can create a campaign with some information and an end date.
2. Organizations lock up a fixed amount and enter a matching ratio up to a certain amount. (The money is locked up in the smart contract)
3. Whenever anyone donates, the corresponding amount multiplied by the matching ratio is deducted from corporate's account and sent to the recipient.
4. When the deadline ends, anyone can call for the campaign to finish.
5. If there is remaining funds left, only the corporation can withdraw the balance
6. The top donor is awarded with a soulbound token.

## Tech Details

Deployed 3 contracts on the Mantle TestNet
One is a contract factory that the charity calls to produce the gift-matching program.
One is the gift-matching program.
The other is the soul-bound token.

- Deployed https://explorer.testnet.mantle.xyz/address/0x3615594d996649741018000670FF6669A4205d83

- https://explorer.testnet.mantle.xyz/address/0xF587535B9C0d3fD1c7579E35771d934E731F8ea6

## To Deploy and call the Smart Contract

npx hardhat run scripts/deploy.js --network mantle-testnet

## App

- Install the Android .apk [HERE](./MatchingDonationUnityGame/Karma%20Farmer.apk) on your mobile phone
- Sign in with metamask (If it does not work, close Metamask and the app and try again. )

## Tech Issues

- Only able to make a simple send transaction with the Metamask Unity SDK on the Mantle TestNet.
- Unable to call smart contract method with data using the Metamask Unity SDK. (Due to lack of documentation)
- Not able to demonstrate the full functionality of the smart contract through the app.

## Future Goals and Improvements

- Ensure metamask can call the smart contract correctly
- Add better gameplay elements
- Social elements

## Learnings

- How to bridge and deploy to the Mantle Network
- Tried out the Metamask Unity SDK for mobile and learnt that it is not production ready. (Deep-linking only works for mono build)
- Exposed to the problems that non-profits face.
