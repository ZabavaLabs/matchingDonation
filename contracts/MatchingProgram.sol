pragma solidity >=0.4.22 <0.9.0;

contract MatchingProgram {
    uint public state;
    address recipient;
    bytes32 recipientName;
    uint initialMatchingAmount;
    uint matchingAmountLeft;
    bytes32 programName;

    event DonatedEvent(uint donatedAmount);
    event MatchingProgramStartedEvent(uint matchingAmount);

    error NoAmountSent();
    error NoMatchingAmountSet();

    // Function to get the current count
    function getState() public view returns (uint) {
        return state;
    }

    function getMatchingAmountLeft() public view returns (uint) {
        return matchingAmountLeft;
    }

    function getInitialMatchingAmount() public view returns (uint) {
        return initialMatchingAmount;
    }

    constructor(
        bytes32 inputProgramName,
        address intendedRecipient,
        bytes32 inputRecipientName
    ) {
        recipient = intendedRecipient;
        recipientName = inputRecipientName;
        programName = inputProgramName;
        state = 0;
    }

    function sendMatchingAmount() external payable {
        if (msg.value == 0) revert NoAmountSent();

        matchingAmountLeft = msg.value;
        initialMatchingAmount = msg.value;

        emit MatchingProgramStartedEvent(matchingAmountLeft);

        state = 1;
    }

    function donate() external payable {
        // msg.value
        if (state == 0) revert NoMatchingAmountSet();
        if (msg.value <= matchingAmountLeft) {
            matchingAmountLeft -= msg.value;
            payable(recipient).transfer(msg.value + msg.value);
            emit DonatedEvent(msg.value + msg.value);
        } else if (msg.value > matchingAmountLeft) {
            uint amountToSend = msg.value + matchingAmountLeft;
            matchingAmountLeft = 0;
            payable(recipient).transfer(amountToSend);
            emit DonatedEvent(amountToSend);
        }
    }
}
