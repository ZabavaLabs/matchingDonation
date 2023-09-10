pragma solidity >=0.4.22 <0.9.0;

import "./MatchingProgram.sol";
import "./CloneFactory.sol";

import "@openzeppelin/contracts/access/Ownable.sol";

contract Factory is CloneFactory, Ownable {
    address public libraryAddress;

    event MatchingProgramCreated(address newProgram);

    constructor(address _libraryAddress) {
        libraryAddress = _libraryAddress;
    }

    function setLibraryAddress(address _libraryAddress) public onlyOwner {
        libraryAddress = _libraryAddress;
    }

    function CreateNewProgram(
        bytes32 inputProgramName,
        bytes32 inputProgramDescription,
        address intendedRecipient,
        bytes32 inputRecipientName,
        uint inputEndTime
    ) public {
        address clone = createClone(libraryAddress);
        MatchingProgram(clone).init(
            inputProgramName,
            inputProgramDescription,
            intendedRecipient,
            inputRecipientName,
            inputEndTime
        );
        emit MatchingProgramCreated(clone);
    }
}
