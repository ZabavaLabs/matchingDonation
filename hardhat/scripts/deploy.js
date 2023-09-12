const hre = require("hardhat");

async function main() {
    // const SBT = await hre.ethers.getContractFactory("SoulBoundToken");
    // // sbt 
    // const sbt = await SBT.deploy();
    // await sbt.deployed();
    // console.log("SBT deployed to: ", sbt.address); // Logs the address to which our contract is deployed


    // const MP = await hre.ethers.getContractFactory("MatchingProgram");
    // //v5
    // const programName = ethers.utils.formatBytes32String("Fundraising For Floods 2023");
    // const programDescString = "Funds for food and clothing for victims";
    // const programDesc = ethers.utils.formatBytes32String("Funds for food");
    // const recipientName = ethers.utils.formatBytes32String("Salvation Army");
    // const category = ethers.utils.formatBytes32String("category1");
    // //dev account 2
    // const recipientAddress = "0x6BA58304cAC6dB50eac3202987f7c3D2638334A7";
    // const sbtOwnerAddress = "0x732f2Ba79F0749785350eC7f6aca140DF3fAD96B";
    // //v6
    
    // //const encoded = ethers.encodeBytes32String("1");

    // const padded = ethers.utils.hexZeroPad('0x1', 32)

    // const address1 = '0xc3f86730B335c9eD84766b629D2dd1D27c804300';
    // const address2 = '0x6BA58304cAC6dB50eac3202987f7c3D2638334A7';

    // // epoch GMT: Saturday, September 23, 2023 9:03:16 PM
    
    // const mp = await MP.deploy(sbtOwnerAddress,category,programName,programDesc,recipientAddress,recipientName,1695502996);
    // await mp.deployed();

    // console.log("MatchingProgram deployed to: ", mp.address); // Logs the address to which our contract is deployed
    
    // // library address
    const Factory = await hre.ethers.getContractFactory("Factory");

    const libAddress = "0x3615594d996649741018000670FF6669A4205d83";
    const factory = await Factory.deploy(libAddress);
    await factory.deployed();
    console.log("Factory deployed to: ", factory.address); // Logs the address to which our contract is deployed


    
}

main()
    .then(() => process.exit(0))
    .catch((error) => {
        console.error(error);
        process.exit(1);
    });