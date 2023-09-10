var MatchingProgramContract = artifacts.require("MatchingProgram");
var FactoryContract = artifacts.require("Factory");


module.exports = async function(deployer) {
  // deploy a contract
  await deployer.deploy(MatchingProgramContract);
  //access information about your deployed contract instance
  const instance = await MatchingProgramContract.deployed();
  var templateAddress = instance.address
  console.log("templateAddress: ",templateAddress);

  const factoryInstance = await FactoryContract.deployed(templateAddress);
  console.log("factoryAddress: ",factoryInstance.address);
}