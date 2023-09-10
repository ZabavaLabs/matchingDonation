pragma solidity >=0.4.22 <0.9.0;

contract MatchingProgram {
    uint public state;
    address recipient;
    bytes32 recipientName;
    address sponsor;
    bytes32 sponsorName;

    uint matchingAmount;
    uint matchingAmountLeft;
    bytes32 programName;
    bytes32 programDescription;

    uint matchingRatio;
    uint endTime;

    mapping(address => uint) donors;
    uint donorCount;

    event DonatedEvent(uint donatedAmount);
    event MatchingProgramStartedEvent(uint matchingAmount);

    error NoAmountSent();
    error PastInitialFundState();
    error NoMatchingAmountSet();
    error FundraiseEnded();
    error FundraiseNotEnded();
    error RatioLessThanOne();

    struct Donation {
        uint amount;
    }

    // Function to get the current count
    function getState() public view returns (uint) {
        return state;
    }

    function getMatchingAmountLeft() public view returns (uint) {
        return matchingAmountLeft;
    }

    function getInitialMatchingAmount() public view returns (uint) {
        return matchingAmount;
    }

    constructor(
        bytes32 inputProgramName,
        bytes32 inputProgramDescription,
        address intendedRecipient,
        bytes32 inputRecipientName,
        address inputSponsor,
        bytes32 inputSponsorName,
        uint inputEndTime
    ) {
        recipient = intendedRecipient;
        recipientName = inputRecipientName;
        sponsor = inputSponsor;
        sponsorName = inputSponsorName;
        programName = inputProgramName;
        programDescription = inputProgramDescription;
        endTime = inputEndTime;
        state = 0;
        donorCount = 0;
    }

    function fundInitialMatchingAccount(uint ratio) external payable {
        if (msg.value == 0) revert NoAmountSent();
        if (state != 0) revert PastInitialFundState();
        if (ratio <= 0) revert RatioLessThanOne();
        if (block.timestamp < endTime) {
            revert FundraiseEnded();
        }
        matchingAmountLeft = msg.value;
        matchingAmount = msg.value;
        matchingRatio = ratio;
        emit MatchingProgramStartedEvent(matchingAmountLeft);
        state = 1;
    }

    function donate() external payable {
        // msg.value
        if (state == 0) revert NoMatchingAmountSet();
        if (block.timestamp < endTime) {
            revert FundraiseEnded();
        }
        uint amountToSend = 0;
        if (msg.value <= matchingRatio * matchingAmountLeft) {
            amountToSend = msg.value * (matchingRatio + 1);
            matchingAmountLeft -= msg.value * matchingRatio;
            payable(recipient).transfer(amountToSend);
        } else if (msg.value > matchingRatio * matchingAmountLeft) {
            amountToSend = msg.value + matchingAmountLeft;
            matchingAmountLeft = 0;
            payable(recipient).transfer(amountToSend);
        }
        if (donors[msg.sender] == 0) {
            donorCount += 1;
        }
        donors[msg.sender] += msg.value;
        emit DonatedEvent(amountToSend);
    }

    function endFundRaise() external {
        if (block.timestamp < endTime) {
            revert FundraiseEnded();
        }
        state = 2;
    }

    function refundMatchingAmount() external {
        if (state < 2) {
            revert FundraiseNotEnded();
        }
        payable(sponsor).transfer(matchingAmountLeft);
    }
}
